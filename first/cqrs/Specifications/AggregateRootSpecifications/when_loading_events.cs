namespace Dahlia.AggregateRootSpecifications
{
    using System;
    using System.Collections.Generic;
    using Dahlia.Domain;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_loading_events
    {
        Establish context =()=>
        {
            aggregateRoot = new TestAggregateRoot();

            historicalEvents = new List<Event>
            {
                new TestEvent(),
                new TestEvent()
            };
        };

        Because of =()=> aggregateRoot.Load(historicalEvents);

        It should_apply_each_event =()=> appliedCounter.ShouldEqual(historicalEvents.Count);

        static TestAggregateRoot aggregateRoot;
        static ICollection<Event> historicalEvents;
        static int appliedCounter;

        private class TestAggregateRoot : AggregateRoot
        {
            internal TestAggregateRoot()
            {
                RegisterHandler<TestEvent>(e => appliedCounter++);
            }
        }

        private class TestEvent : Event
        {
        }
    }
}
