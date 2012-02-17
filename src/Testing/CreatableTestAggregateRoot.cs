/*
namespace Dahlia.Domain
{
    using System;
    using Dahlia.Events.Testing;

    public abstract class CreatableTestAggregateRoot : AggregateRoot
    {
        protected CreatableTestAggregateRoot()
        {
            RegisterHandler<CreateTestEvent>(e => Id = e.AggregateRootId);
        }

        public void Create(Guid id)
        {
            Id = id;

            Apply(new CreateTestEvent());
        }
    }
}
*/
