namespace Dahlia.Domain
{
    using System;

    public class AggregateRootNotCreatedException : Exception
    {
        public AggregateRootNotCreatedException(AggregateRoot aggregateRoot) : this(aggregateRoot.GetType())
        {
        }

        public AggregateRootNotCreatedException(Type aggregateRoot) : base("The " + aggregateRoot + " was not created")
        {
            AggregateRoot = aggregateRoot;
        }

        public Type AggregateRoot { get; private set; }
    }
}
