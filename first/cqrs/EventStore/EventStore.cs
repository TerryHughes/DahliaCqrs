namespace Dahlia.EventStores
{
    using System;
    using System.Collections.Generic;
    using Dahlia.Domain;
    using Dahlia.Events;

    public abstract class EventStore
    {
        public void Perform<T>(Action<T> action, Guid against) where T : AggregateRoot, new()
        {
            lock (this)
            {
                var eventsFor = EventsFor(against);

                var aggregateRoot = new T();
                aggregateRoot.Load(eventsFor);

                action(aggregateRoot);

                foreach (var extractEvent in aggregateRoot.ExtractEvents())
                {
                    AddEvent(extractEvent);
                }
            }
        }

        protected abstract IEnumerable<Event> EventsFor(Guid aggregateRootId);
        protected abstract void AddEvent(Event @event);
    }
}
