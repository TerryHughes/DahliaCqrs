namespace Dahlia.AggregateRootSpecifications
{
    using Dahlia.Domain;
    using Machine.Specifications;

    public class when_not_created
    {
        Establish context =()=> aggregateRoot = new TestAggregateRoot();

        Because of =()=> exception = Catch.Exception(() => aggregateRoot.CallGuard()) as AggregateRootNotCreatedException;

        It should_throw_an_AggregateRootNotCreatedException =()=> exception.ShouldNotBeNull();

        static TestAggregateRoot aggregateRoot;
        static AggregateRootNotCreatedException exception;

        private class TestAggregateRoot : AggregateRoot
        {
            internal void CallGuard()
            {
                Guard();
            }
        }
    }
}
