namespace Dahlia.DataStore
{
    using System;
    using Events.RetreatCreatedEvent;
    using Handlers;

    static class Program
    {
        static void Main()
        {
            var line = String.Empty;

            var handler = new RetreatCreatedEventHandler();
            var random = new Random();

            while ((line = Console.ReadLine()) != String.Empty)
                handler.Handle(new Version1
                {
                    AggregateRootId = Guid.NewGuid(),
                    Date = DateTime.Today.AddDays(random.Next(-100, 100)),
                    Description = line
                });
        }
    }
}
