namespace Dahlia.EventStoreSpecifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;
    using Dahlia.EventStores;
    using Machine.Specifications;

    public class when_dealing_with_events
    {
        Establish context =()=> eventStore = new TestEventStore();

        Because of =()=> new Action(() => eventStore.Perform<TestAggregateRoot>(a => a.Action(after), Guid.Empty))
            .DelayExecution(20)
            .ExecuteInTheMiddleOf(() => eventStore.Perform<TestAggregateRoot>(a => new Action(() => a.Action(before)).DelayExecution(50)(), Guid.Empty));

        It should_be_thread_safe =()=>
        {
            eventStore.EventsAdded.Count.ShouldEqual(2);
            (eventStore.EventsAdded[0] as TestEvent).Name.ShouldEqual(before);
            (eventStore.EventsAdded[1] as TestEvent).Name.ShouldEqual(after);
        };

        static TestEventStore eventStore;
        static string before = "before";
        static string after = "after";

        private class TestEventStore : EventStore
        {
            internal readonly IList<Event> EventsAdded = new List<Event>();

            protected override IEnumerable<Event> EventsFor(Guid aggregateRootId)
            {
                return Enumerable.Empty<Event>();
            }

            protected override void AddEvent(Event @event)
            {
                EventsAdded.Add(@event);
            }
        }

        private class TestAggregateRoot : CreatableTestAggregateRoot
        {
            public TestAggregateRoot()
            {
                RegisterHandler<TestEvent>(e => { });
            }

            internal void Action(string name)
            {
                Apply(new TestEvent(name));
            }
        }

        private class TestEvent : Event
        {
            internal readonly string Name;

            internal TestEvent(string name)
            {
                Name = name;
            }
        }
    }
}
