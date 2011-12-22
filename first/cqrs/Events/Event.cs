namespace Dahlia.Events
{
    using System;
    using Dahlia.Framework;

    public abstract class Event
    {
        public Guid Id { get; private set; }
        public Guid AggregateRootId { get; set; }
        public int AggregateRootVersion { get; set; }

        protected Event()
        {
            Id = SystemGuid.NewGuid();
        }
    }
}
