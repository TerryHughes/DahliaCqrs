namespace Dahlia.Commands
{
    using System;
    using Dahlia.Framework;

    public abstract class Command
    {
        public Guid Id { get; private set; }
        public Guid AggregateRootId { get; set; }

        protected Command()
        {
            Id = SystemGuid.NewGuid();
        }
    }
}
