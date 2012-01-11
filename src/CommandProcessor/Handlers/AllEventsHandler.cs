namespace Dahlia.CommandProcessor
{
    using System;
    using System.Linq;
    using NServiceBus;
    using Domain;
    using EventStores;
    using Events;

    public class AllEventsHandler : IHandleMessages<AllEvents>
    {
        readonly IBus bus;

        public AllEventsHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(AllEvents allEvents)
        {
            var events = new TempAllEvents().GetAll();

            foreach (var @event in events)
                bus.Publish(@event);
        }
    }
}
