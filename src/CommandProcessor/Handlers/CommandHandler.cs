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
            var events = eventStore.Perform<TAggregateRoot>(r => Action(command, r), Against(command));

            foreach (var @event in events)
            {
                @event.CommandId = command.Id;

                bus.Publish(@event);
            }
        }

        protected abstract void Action(TCommand command, TAggregateRoot aggregateRoot);

        protected virtual Guid Against(TCommand command)
        {
            return command.AggregateRootId;
        }
    }
}
