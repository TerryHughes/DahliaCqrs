namespace Dahlia.AggregateRootSpecifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_dealing_with_appliedEvents
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

        Because of =()=> new Action(() => aggregateRoot.ApplyAnEvent())
            .DelayExecution(20)
            .ExecuteInTheMiddleOf(() => events = aggregateRoot.ExtractEvents().SlowlyEnumerate(10).ToList());

        It should_be_thread_safe =()=>
        {
            events.Count().ShouldEqual(existingEvents);
            aggregateRoot.ExtractEvents().Count().ShouldEqual(1);
        };

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
