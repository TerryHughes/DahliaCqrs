namespace Dahlia.EventComparerSpecifications
{
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_the_AggregateRootIds_are_empty
    {
        Establish context =()=>
        {
            x = new TestEvent();
            y = new TestEvent();
        };

        Because of =()=> result = new EventComparer().Equals(x, y);

        It should_return_false =()=> result.ShouldBeFalse();

        static Event x;
        static Event y;
        static bool result;

        private class TestEvent : Event
        {
        }
    }
}
