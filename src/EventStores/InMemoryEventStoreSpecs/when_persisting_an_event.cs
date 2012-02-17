/*
namespace Dahlia.InMemoryEventStoreSpecifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Events;
    using Dahlia.EventStores;
    using Machine.Specifications;

    public class when_persisting_an_event
    {
        Establish context =()=>
        {
            aggregatRootId = Guid.NewGuid();

            eventStore = new InMemoryEventStore();

            @event = new TestEvent();
        };

        Because of =()=> eventStore.InvokeNonPublicInstanceMethod("AddEvent", new object[] { @event });

        It should_add_the_event_to_its_list =()=>
        {
            eventStore.GetNonPublicInstanceField<ICollection<Event>>("events").Count.ShouldEqual(1);
            eventStore.GetNonPublicInstanceField<ICollection<Event>>("events").First().ShouldEqual(@event);
        };

        static Guid aggregatRootId;
        static InMemoryEventStore eventStore;
        static Event @event;

        private class TestEvent : Event
        {
        }
    }
}
*/
