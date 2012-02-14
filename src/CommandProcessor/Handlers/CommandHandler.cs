namespace Dahlia.CommandProcessor
{
    using System;
    using NServiceBus;
    using Commands;
    using Domain;
    using EventStores;

    public abstract class CommandHandler<TCommand, TAggregateRoot> : IHandleMessages<TCommand>
        where TCommand : Command
        where TAggregateRoot : AggregateRoot, new()
    {
        readonly EventStore eventStore;
        readonly IBus bus;

        protected CommandHandler(EventStore eventStore, IBus bus)
        {
            this.eventStore = eventStore;
            this.bus = bus;
        }

        public void Handle(TCommand command)
        {
            // we just lost locking and syncing

            var eventsFor = eventStore.EventsFor(Against(command));

            var aggregateRoot = new TAggregateRoot();
var watch = System.Diagnostics.Stopwatch.StartNew();
            aggregateRoot.Load(eventsFor);
watch.Stop();
System.Console.WriteLine(aggregateRoot.Id + " took " + watch.ElapsedMilliseconds + "ms to load");

            Action(command, aggregateRoot);

            foreach (var extractedEvent in aggregateRoot.ExtractEvents())
            {
                extractedEvent.CommandId = command.Id;

                eventStore.AddEvent(extractedEvent);
                bus.Publish(extractedEvent);
            }
        }

        protected virtual Guid Against(TCommand command)
        {
            return command.AggregateRootId;
        }

        protected abstract void Action(TCommand command, TAggregateRoot aggregateRoot);
    }
}
