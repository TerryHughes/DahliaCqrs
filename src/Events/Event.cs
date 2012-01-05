namespace Dahlia.Events
{
    using System;
    using NServiceBus;
    using Framework;

    [Serializable]
    public abstract class Event : IMessage
    {
        public Guid Id { get; set; }
        public Guid CommandId { get; set; }
        public Guid AggregateRootId { get; set; }
        //public int AggregateRootVersion { get; set; }

        protected Event()
        {
            Id = SystemGuid.NewGuid();
        }
    }
}
