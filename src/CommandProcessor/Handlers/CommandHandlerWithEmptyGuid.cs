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

        // sealing not recomended? http://stackoverflow.com/questions/4673967/is-it-possible-to-finalize-a-virtual-method-in-c
        protected override sealed Guid Against(TCommand command)
        {
            return Guid.Empty;
        }
    }
}
