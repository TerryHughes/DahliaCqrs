namespace Dahlia.EventComparerSpecifications
{
    using System;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_the_AggregateRootIds_do_not_match
    {
        Establish context =()=>
        {
            x = new TestEvent { AggregateRootId = Guid.NewGuid() };
            y = new TestEvent { AggregateRootId = Guid.NewGuid() };
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
