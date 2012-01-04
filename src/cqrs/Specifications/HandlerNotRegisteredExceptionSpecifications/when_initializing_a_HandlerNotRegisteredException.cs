namespace Dahlia.HandlerNotRegisteredExceptionSpecifications
{
    using Dahlia.Domain;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_initializing_a_HandlerNotRegisteredException
    {
        Establish context =()=>
        {
            aggregateRoot = new TestAggregateRoot();
            @event = new TestEvent();
        };

        Because of =()=> exception = new HandlerNotRegisteredException(aggregateRoot, @event);

        It should_have_a_useful_message =()=> exception.Message.ShouldEqual("There was no registered handler for the " + @event.GetType() + " on " + aggregateRoot.GetType());

        It should_say_what_type_of_aggregate_root_was_involved =()=> exception.AggregateRoot.ShouldEqual(aggregateRoot.GetType());

        It should_say_what_type_of_event_was_involved =()=> exception.Event.ShouldEqual(@event.GetType());

        static TestAggregateRoot aggregateRoot;
        static TestEvent @event;
        static HandlerNotRegisteredException exception;

        private class TestAggregateRoot : AggregateRoot
        {
        }

        private class TestEvent : Event
        {
        }
    }
}
