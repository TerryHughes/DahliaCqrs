namespace Dahlia.EventStores
{
    using System;
    using System.Collections.Generic;
using System.Linq;
    using Domain;
    using Events;

    public abstract class EventStore
    {
        readonly object syncroot = new object();

        public IEnumerable<Event> Perform<T>(Action<T> action, Guid against) where T : AggregateRoot, new()
        {
            lock (syncroot)
            {
                var eventsFor = EventsFor(against);
Console.WriteLine("attempting a pull");
Console.WriteLine("there are " + EventsFor(Guid.Parse("55E54863-B185-4DB5-A240-D0FE960699CA")).Count() + " events");

                var aggregateRoot = new T();
                aggregateRoot.Load(eventsFor);

                action(aggregateRoot);

                foreach (var extractedEvent in aggregateRoot.ExtractEvents())
                {
                    AddEvent(extractedEvent);

                    yield return extractedEvent;
                }
            }
        }

        protected abstract IEnumerable<Event> EventsFor(Guid aggregateRootId);
        protected abstract void AddEvent(Event @event);
    }
}
