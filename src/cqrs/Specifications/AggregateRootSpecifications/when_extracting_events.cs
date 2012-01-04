namespace Dahlia.AggregateRootSpecifications
{
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_extracting_events
    {
        Establish context =()=>
        {
            aggregateRoot = new TestAggregateRoot();

            existingEvents = 4;
            for (var i = 0; i < existingEvents; i++)
            {
                aggregateRoot.ApplyAnEvent();
            }
        };

        Because of =()=>
        {
            events = aggregateRoot.ExtractEvents();
            aggregateRoot.ApplyAnEvent();
        };

        It should_be_delayed =()=> events.Count().ShouldEqual(existingEvents + 1);

        It should_clear_the_events =()=> aggregateRoot.ExtractEvents().Count().ShouldEqual(0);

        static TestAggregateRoot aggregateRoot;
        static int existingEvents;
        static IEnumerable<Event> events;

        private class TestAggregateRoot : AggregateRoot
        {
            internal TestAggregateRoot()
            {
                RegisterHandler<TestEvent>(e => { });
            }

            internal void ApplyAnEvent()
            {
                Apply(new TestEvent());
            }
        }

        private class TestEvent : Event
        {
        }
    }
}
