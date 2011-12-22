namespace Dahlia.DataStore.Handlers
{
    using System;
    using NServiceBus;
    using Events;

    public class LogEventHandler : IHandleMessages<Event>
    {
        public void Handle(Event @event)
        {
            Console.WriteLine("Logging event handler says: " + @event.GetType());
        }
    }
}
