namespace Dahlia.Events.EventComparerSpecs
{
    using System;
    using Machine.Specifications;

    public class when_the_field_values_do_match
    {
        Establish context =()=>
        {
            var value = "value";
            var guid = Guid.NewGuid();

            x = new TestEvent(value) { AggregateRootId = guid };
            y = new TestEvent(value) { AggregateRootId = guid };

            comparer = new EventComparer();
        };

        Because of =()=> result = comparer.Equals(x, y);

        It should_return_true =()=> result.ShouldBeTrue();

        It should_return_the_same_hash_codes =()=> comparer.GetHashCode(x).ShouldEqual(comparer.GetHashCode(y));

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
