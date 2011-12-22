namespace Dahlia.AggregateRootSpecifications
{
    using System;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_applying_an_event
    {
        Establish context =()=>
        {
            id = Guid.NewGuid();

            aggregateRoot = new TestAggregateRoot();
            aggregateRoot.SetId(id);

            @event = new TestEvent();
        };

        Because of =()=> aggregateRoot.CallApply(@event);

        It should_apply_its_Id_to_the_event =()=> @event.AggregateRootId.ShouldEqual(id);

        It should_apply_the_event =()=> executed.ShouldBeTrue();

        It should_remember_what_events_were_applied =()=>
        {
            var extractEvents = aggregateRoot.ExtractEvents().ToList();

            extractEvents.Count.ShouldEqual(1);
            extractEvents[0].ShouldEqual(@event);
        };

        static Guid id;
        static TestAggregateRoot aggregateRoot;
        static TestEvent @event;
        static bool executed;

        private class TestAggregateRoot : AggregateRoot
        {
            internal TestAggregateRoot()
            {
                RegisterHandler<TestEvent>(e => executed = true);
            }

            internal void SetId(Guid id)
            {
                Id = id;
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
