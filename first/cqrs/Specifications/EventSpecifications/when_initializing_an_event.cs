namespace Dahlia.EventSpecifications
{
    using System;
    using Dahlia.Events;
    using Dahlia.Framework;
    using Machine.Specifications;

    public class when_initializing_an_event
    {
        Establish context =()=>
        {
            guid = Guid.NewGuid();
            SystemGuid.FromNowOnReturn(guid);
        };

        Because of =()=> @event = new TestEvent();

        It should_set_its_Id =()=> @event.Id.ShouldEqual(guid);

        Cleanup mess =()=> SystemGuid.FromNowOnGenerateNew();

        static Guid guid;
        static Event @event;

        private class TestEvent : Event
        {
        }
    }
}
