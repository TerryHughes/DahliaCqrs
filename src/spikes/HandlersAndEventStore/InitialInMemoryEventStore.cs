namespace Dahlia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;

    public class InitialInMemoryEventStore
    {
        private static readonly ICollection<Event> BackingStore = new List<Event>();

        public IEnumerable<Event> RetrieveEventsFor(Guid aggregateRootId)
        {
            lock (BackingStore)
            {
                return BackingStore
                    .Where(e => e.AggregateRootId == aggregateRootId)
                    .OrderBy(e => e.AggregateRootVersion);
            }
        }

        public void Store(AggregateRoot aggregateRoot)
        {
            lock (BackingStore)
            {
                var version = aggregateRoot.BuiltFromVersion;
                var lastEvent = RetrieveEventsFor(aggregateRoot.Id).Last();
                if ((lastEvent != null) && (version != lastEvent.AggregateRootVersion))
                {
                    throw new EventStoreConcurrencyException(aggregateRoot.GetType(), aggregateRoot.Id, version, lastEvent.AggregateRootVersion);
                }

                foreach (var @event in aggregateRoot.ExtractEvents())
                {
                    @event.AggregateRootVersion = version++;

                    BackingStore.Add(@event);
                }
            }
        }
    }

    public class EventStoreConcurrencyException : Exception
    {
        public EventStoreConcurrencyException(Type aggregateRootType, Guid aggregateRootId, int expectedVersion, int actualVersion) : base(String.Format("Attempting to store the events from {0} {1} at version {2}. but other events have updated it to version {3}", aggregateRootType, aggregateRootId, expectedVersion, actualVersion))
        {
        }
    }
}
