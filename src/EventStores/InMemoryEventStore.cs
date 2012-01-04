/*
namespace Dahlia.EventStores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public class InMemoryEventStore : EventStore
    {
        public readonly ICollection<Event> events;

        public InMemoryEventStore()
        {
            events = new List<Event>();
        }

        protected override IEnumerable<Event> EventsFor(Guid aggregateRootId)
        {
            return events.Where(e => e.AggregateRootId == aggregateRootId);
        }

        protected override void AddEvent(Event @event)
        {
            events.Add(@event);
        }
    }
}
*/
