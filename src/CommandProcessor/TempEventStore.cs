namespace Dahlia.EventStores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public class TempEventStore : EventStore
    {
        protected override IEnumerable<Event> EventsFor(Guid aggregateRootId)
        {
            return Enumerable.Empty<Event>();
        }

        protected override void AddEvent(Event @event)
        {
        }
    }
}
