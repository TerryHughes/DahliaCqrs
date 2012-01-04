namespace Dahlia.EventComparerSpecifications
{
    using System;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_the_field_values_do_not_match
    {
        Establish context =()=>
        {
            var guid = Guid.NewGuid();

            x = new TestEvent("value1") { AggregateRootId = guid };
            y = new TestEvent("value2") { AggregateRootId = guid };

            comparer = new EventComparer();
        };

        Because of =()=> result = comparer.Equals(x, y);

        It should_return_false =()=> result.ShouldBeFalse();

        It should_return_different_hash_codes =()=> comparer.GetHashCode(x).ShouldNotEqual(comparer.GetHashCode(y));

        static Event x;
        static Event y;
        static EventComparer comparer;
        static bool result;

        private class TestEvent : Event
        {
            public readonly string Value;

            internal TestEvent(string value)
            {
                Value = value;
            }
        }
    }
}
