namespace Dahlia.EventStores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Events;

    public class InMemoryEventStore : EventStore
    {
        private readonly ICollection<Event> events = new List<Event>();

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
