namespace Dahlia.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Events;

    public abstract class AggregateRoot
    {
        private readonly ICollection<Event> appliedEvents = new List<Event>();
        private readonly IDictionary<Type, Func<Event, Event>> converters = new Dictionary<Type, Func<Event, Event>>();
        private readonly IDictionary<Type, Action<Event>> handlers = new Dictionary<Type, Action<Event>>();

        public Guid Id { get; protected set; }
        public int BuiltFromVersion { get; private set; }

        public void Load(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                InternalApply(@event);

                BuiltFromVersion = @event.AggregateRootVersion;
            }
        }

        public IEnumerable<Event> ExtractEvents()
        {
            lock (appliedEvents)
            {
                foreach (var appliedEvent in appliedEvents)
                {
                    yield return appliedEvent;
                }

                appliedEvents.Clear();
            }
        }

        protected void Apply(Event @event)
        {
            @event.AggregateRootId = Id;

            InternalApply(@event);

            lock (appliedEvents)
            {
                appliedEvents.Add(@event);
            }
        }

        protected virtual void Guard()
        {
            EnsureAggregateRootIsCreated();
        }

        protected void RegisterConverter<TInput, TOutput>(Func<TInput, TOutput> converter) where TInput : Event where TOutput : Event
        {
            converters.Add(typeof(TInput), e => converter(e as TInput));
        }

        protected void RegisterHandler<T>(Action<T> handler) where T : Event
        {
            var type = typeof(T);

            foreach (var version in type.Assembly.GetTypes().Where(t => t.Namespace == type.Namespace && typeof(Event).IsAssignableFrom(t)))
            {
                handlers.Add(version, e => handler(Convert(e) as T));
            }
        }

        private Event Convert(Event @event)
        {
            var @try = converters.TryGetValue(@event.GetType());

            return @try.Succeeded ? Convert(@try.Value(@event)) : @event;
        }

        private void InternalApply(Event @event)
        {
            var @try = handlers.TryGetValue(@event.GetType());

            if (@try.Failed)
            {
                throw new HandlerNotRegisteredException(this, @event);
            }

            @try.Value(@event);
        }

        private void EnsureAggregateRootIsCreated()
        {
            if (Id == Guid.Empty)
            {
                throw new AggregateRootNotCreatedException(this);
            }
        }
    }
}
