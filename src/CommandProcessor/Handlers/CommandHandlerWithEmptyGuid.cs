namespace Dahlia.CommandProcessor
{
    using System;
    using NServiceBus;
    using Commands;
    using Domain;
    using EventStores;

    public abstract class CommandHandlerWithEmptyGuid<TCommand, TAggregateRoot> : CommandHandler<TCommand, TAggregateRoot>
        where TCommand : Command
        where TAggregateRoot : AggregateRoot, new()
    {
        protected CommandHandlerWithEmptyGuid(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override Guid Against(TCommand command)
        {
            return Guid.Empty;
        }
    }
}
