namespace Dahlia.DataStore.Handlers
{
    using NServiceBus;
    using Dahlia.Events;

    public class LogEventHandler : IHandleMessages<Event>
    {
        public void Handle(Event @event)
        {
            System.Console.WriteLine("Logging event handler says: " + @event.GetType());
        }
    }
}
