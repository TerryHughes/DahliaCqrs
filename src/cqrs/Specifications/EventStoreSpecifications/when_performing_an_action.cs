namespace Dahlia.EventStoreSpecifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;
    using Dahlia.EventStores;
    using Machine.Specifications;

    public class when_performing_an_action
    {
        Establish context =()=>
        {
            aggregateRootId = Guid.NewGuid();

            eventStore = new TestEventStore();

            loadedEvents = 4;
            for (var i = 0; i < loadedEvents; i++)
            {
                eventStore.EventsToLoad.Add(new TestEvent());
            }

            @event = new TestEvent();
        };

        Because of =()=> eventStore.Perform<TestAggregateRoot>(a =>
        {
            a.CallApply(@event);
            aggregateRootBeingPerformedOn = a;
        }, aggregateRootId);

        It should_get_the_events_to_load =()=> eventStore.AggregateRootId.ShouldEqual(aggregateRootId);

        It should_load_the_events_to_the_aggregate_root =()=> aggregateRootBeingPerformedOn.HandledEvents.SequenceEqual(eventStore.EventsToLoad.Union(new[] { @event })).ShouldBeTrue();

        It should_extract_the_events_from_the_aggregate_root =()=> aggregateRootBeingPerformedOn.ExtractEvents().Count().ShouldEqual(0);

        It should_persist_the_extracted_events =()=> eventStore.EventAdded.ShouldEqual(@event);

        static Guid aggregateRootId;
        static TestEventStore eventStore;
        static int loadedEvents;
        static Event @event;
        static TestAggregateRoot aggregateRootBeingPerformedOn;

        private class TestEventStore : EventStore
        {
            internal readonly ICollection<Event> EventsToLoad = new List<Event>();
            internal Guid AggregateRootId;
            internal Event EventAdded;

            protected override IEnumerable<Event> EventsFor(Guid aggregateRootId)
            {
                AggregateRootId = aggregateRootId;

                return EventsToLoad;
            }

            protected override void AddEvent(Event @event)
            {
                EventAdded = @event;
            }
        }

        private class TestAggregateRoot : CreatableTestAggregateRoot
        {
            internal readonly ICollection<Event> HandledEvents = new List<Event>();

            public TestAggregateRoot()
            {
                RegisterHandler<TestEvent>(HandledEvents.Add);
            }

            internal void CallApply(Event @event)
            {
                Apply(@event);
            }
        }

        private class TestEvent : Event
        {
        }
    }
}
