/*
namespace Dahlia.InMemoryEventStoreSpecifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Events;
    using Dahlia.EventStores;
    using Machine.Specifications;

    public class when_getting_the_events_for_an_aggregate_root
    {
        Establish context =()=>
        {
            aggregatRootId = Guid.NewGuid();

            eventStore = new InMemoryEventStore();
            eventStore.SetNonPublicInstanceField("events", new List<Event>
                {
                    new TestEvent { AggregateRootId = aggregatRootId },
                    new TestEvent { AggregateRootId = Guid.NewGuid() },
                    new TestEvent { AggregateRootId = aggregatRootId },
                });
        };

        Because of =()=> events = eventStore.InvokeNonPublicInstanceMethod<IEnumerable<Event>>("EventsFor", new object[] { aggregatRootId });

        It should_return_only_the_events_for_the_aggregate_root =()=> events.Count().ShouldEqual(2);

        static Guid aggregatRootId;
        static InMemoryEventStore eventStore;
        static IEnumerable<Event> events;

        private class TestEvent : Event
        {
        }
    }
}
*/
