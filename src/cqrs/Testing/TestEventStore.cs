namespace Dahlia.EventStores
{
    using System;
    using System.Collections.Generic;
    using Dahlia.Events;

    public class TestEventStore : EventStore
    {
        public readonly ICollection<Event> EventsToLoad = new List<Event>();
        public readonly ICollection<Event> AddedEvents = new List<Event>();

        protected override IEnumerable<Event> EventsFor(Guid aggregateRootId)
        {
            return EventsToLoad;
        }

        protected override void AddEvent(Event @event)
        {
            AddedEvents.Add(@event);
        }
    }
}
