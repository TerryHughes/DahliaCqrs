namespace Dahlia.CreatableTestAggregateRootSpecifications
{
    using System;
    using System.Linq;
    using Dahlia.Domain;
    using Machine.Specifications;

    public class when_creating
    {
        Establish context =()=>
        {
            id = Guid.NewGuid();
            aggregateRoot = new TestAggregateRoot();
        };

        Because of =()=> aggregateRoot.Create(id);

        It should_set_the_id =()=> aggregateRoot.ExtractEvents().First().AggregateRootId.ShouldEqual(id);

        static Guid id;
        static CreatableTestAggregateRoot aggregateRoot;

        private class TestAggregateRoot : CreatableTestAggregateRoot
        {
        }
    }
}
