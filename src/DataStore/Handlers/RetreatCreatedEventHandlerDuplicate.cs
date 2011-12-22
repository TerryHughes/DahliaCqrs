namespace Dahlia.DataStore.Handlers
{
    using System.Data.SqlClient;
    using NServiceBus;
    using PreviousRetreatCreatedEvent = Dahlia.Events.RetreatCreatedEvent.Version1;

    public class RetreatCreatedEventHandlerDuplicate : IHandleMessages<PreviousRetreatCreatedEvent>
    {
        public void Handle(PreviousRetreatCreatedEvent @event)
        {
            System.Console.WriteLine("duplicate got the event");
        }
    }
}
