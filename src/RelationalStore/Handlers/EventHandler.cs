namespace Dahlia.RelationalStore
{
    using System.Collections.Generic;
    using NServiceBus;
    using Data.Common;
    using Events;
    using Framework;

    public abstract class EventHandler<T> : IHandleMessages<T> where T : Event
    {
        readonly WriteRepository repository;

        public EventHandler(WriteRepository repository)
        {
            this.repository = repository;
        }

        protected abstract string Statement { get; }

        public void Handle(T @event)
        {
System.Console.WriteLine("handling " + @event.Id + " which is a " + @event.GetType() + " in " + this.GetType());
            repository.Do(Statement, ComposePairsWithId(@event));
        }

        IEnumerable<KeyValuePair<string, object>> ComposePairsWithId(T @event)
        {
            yield return new KeyValuePair<string, object>("@Id", @event.AggregateRootId);

            foreach (var pair in ComposePairs(@event))
                yield return pair;
        }

        protected abstract IEnumerable<KeyValuePair<string, object>> ComposePairs(T @event);
    }
}