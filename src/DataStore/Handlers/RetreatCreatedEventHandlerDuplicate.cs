namespace Dahlia.DataStore.Handlers
{
    using System;
    using System.Data.SqlClient;
    using NServiceBus;
    using RetreatCreatedEvent = Events.RetreatCreatedEvent.Version1;

    public class RetreatCreatedEventHandlerDuplicate : IHandleMessages<RetreatCreatedEvent>
    {
        public void Handle(RetreatCreatedEvent @event)
        {
            Console.WriteLine("duplicate got the event");
        }
    }
}
