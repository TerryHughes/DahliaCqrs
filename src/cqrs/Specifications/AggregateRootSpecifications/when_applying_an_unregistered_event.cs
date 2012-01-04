namespace Dahlia.AggregateRootSpecifications
{
    using Dahlia.Domain;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_applying_an_unregistered_event
    {
        Establish context =()=> aggregateRoot = new TestAggregateRoot();

        Because of =()=> exception = Catch.Exception(() => aggregateRoot.ApplyAnUnregisteredEvent()) as HandlerNotRegisteredException;

        It should_throw_a_HandlerNotRegisteredException =()=> exception.ShouldNotBeNull();

        static TestAggregateRoot aggregateRoot;
        static HandlerNotRegisteredException exception;

        private class TestAggregateRoot : AggregateRoot
        {
            internal void ApplyAnUnregisteredEvent()
            {
                Apply(new TestEvent());
            }
        }

        private class TestEvent : Event
        {
        }
    }
}
