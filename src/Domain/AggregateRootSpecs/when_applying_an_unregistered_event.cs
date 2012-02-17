namespace Dahlia.Domain.AggregateRootSpecs
{
    using Machine.Specifications;
    using Events;

    public class when_applying_an_unregistered_event
    {
        Establish context =()=> aggregateRoot = new TestAggregateRoot();

        Because of =()=> exception = Catch.Exception(() => aggregateRoot.ApplyAnUnregisteredEvent()) as HandlerNotRegisteredException;

        It should_throw_a_HandlerNotRegisteredException =()=> exception.ShouldNotBeNull();

        static TestAggregateRoot aggregateRoot;
        static HandlerNotRegisteredException exception;

        class TestAggregateRoot : AggregateRoot
        {
            internal void ApplyAnUnregisteredEvent()
            {
                Apply(new TestEvent());
            }
        }

        class TestEvent : Event
        {
        }
    }
}
