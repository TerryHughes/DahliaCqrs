namespace Dahlia.EventComparerSpecifications
{
    using System;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_the_types_do_not_match
    {
        Establish context =()=>
        {
            var guid = Guid.NewGuid();

            x = new TestEvent1 { AggregateRootId = guid };
            y = new TestEvent2 { AggregateRootId = guid };
        };

        Because of =()=> result = new EventComparer().Equals(x, y);

        It should_return_false =()=> result.ShouldBeFalse();

        static Event x;
        static Event y;
        static bool result;

        private class TestEvent1 : Event
        {
        }

        private class TestEvent2 : Event
        {
        }
    }
}
