namespace Dahlia.EventStores
{
    using System;
    using System.Collections.Generic;
    using Events;

    public interface EventStore
    {
        IEnumerable<Event> EventsFor(Guid aggregateRootId);
        void AddEvent(Event @event);
    }
}
