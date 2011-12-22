namespace Dahlia.Commands
{
    using System;
    using NServiceBus;
    using Framework;

    public abstract class Command : IMessage
    {
        public Guid Id { get; set; }
        public Guid AggregateRootId { get; set; }

        protected Command()
        {
            Id = SystemGuid.NewGuid();
        }
    }
}
