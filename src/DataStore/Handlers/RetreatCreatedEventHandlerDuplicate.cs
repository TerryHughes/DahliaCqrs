namespace Dahlia.DataStore.Handlers
{
    using System;
    using System.Data.SqlClient;
    using NServiceBus;
    using CurrentRetreatCreatedEvent = Events.RetreatCreatedEvent.Version1;

    public class RetreatCreatedEventHandlerDuplicate : IHandleMessages<CurrentRetreatCreatedEvent>
    {
        public void Handle(CurrentRetreatCreatedEvent @event)
        {
            Console.WriteLine("duplicate got the event");
        }
    }
}
