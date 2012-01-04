namespace Dahlia.Domain
{
    using System;
    using Events;

    public class HandlerNotRegisteredException : Exception
    {
        public HandlerNotRegisteredException(AggregateRoot aggregateRoot, Event @event) : this(aggregateRoot.GetType(), @event.GetType())
        {
        }

        public HandlerNotRegisteredException(Type aggregateRoot, Type @event) : base("There was no registered handler for the " + @event + " on " + aggregateRoot)
        {
            AggregateRoot = aggregateRoot;
            Event = @event;
        }

        public Type AggregateRoot { get; private set; }
        public Type Event { get; private set; }
    }
}
