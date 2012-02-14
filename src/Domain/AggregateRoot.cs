namespace Dahlia.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public abstract class AggregateRoot
    {
        readonly object syncroot = new object();
        readonly ICollection<Event> appliedEvents;
        readonly IDictionary<Type, Func<Event, Event>> converters;
        readonly IDictionary<Type, Action<Event>> handlers;

        public AggregateRoot()
        {
            appliedEvents = new List<Event>();
            converters = new Dictionary<Type, Func<Event, Event>>();
            handlers = new Dictionary<Type, Action<Event>>();
        }

        public Guid Id { get; protected set; }
//        public int BuiltFromVersion { get; private set; }

        public IEnumerable<Event> ExtractEvents()
        {
            lock (syncroot)
            {
                foreach (var appliedEvent in appliedEvents)
                    yield return appliedEvent;

                appliedEvents.Clear();
            }
        }

        public void Load(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                InternalApply(@event);

//                BuiltFromVersion = @event.AggregateRootVersion;
            }
        }

        protected void Apply(Event @event)
        {
            @event.AggregateRootId = Id;

            InternalApply(@event);

            lock (syncroot)
                appliedEvents.Add(@event);
        }

        protected virtual void Gaurd()
        {
            EnsureAggregateRootIsCreated();
        }

        protected void RegisterConverter<TInput, TOutput>(Func<TInput, TOutput> converter)
            where TInput : Event
            where TOutput : Event
        {
            converters.Add(typeof(TInput), e => converter(e as TInput));
        }

        protected void RegisterHandler<T>(Action<T> handler)
            where T : Event
        {
            var type = typeof(T);

            foreach (var version in type.Assembly.GetTypes().Where(t => t.Namespace == type.Namespace && typeof(Event).IsAssignableFrom(t)))
                handlers.Add(version, e => handler(Convert(e) as T));
        }

        Event Convert(Event @event)
        {
            var @try = converters.TryGetValue(@event.GetType());

            return @try.Succeeded ? Convert(@try.Value(@event)) : @event;
        }

        void InternalApply(Event @event)
        {
            var @try = handlers.TryGetValue(@event.GetType());

            if (@try.Failed)
                throw new HandlerNotRegisteredException(this, @event);

System.Console.WriteLine("applying: " + @event.Id);
            @try.Value(@event);
        }

        void EnsureAggregateRootIsCreated()
        {
            if (Id == Guid.Empty)
                throw new AggregateRootNotCreatedException(this);
        }
    }
}
