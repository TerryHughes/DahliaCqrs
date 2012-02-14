namespace Dahlia.Events.EventSpecs
{
    using System;
    using Machine.Specifications;
    using Framework;

    public class when_initializing_an_event
    {
        Establish context =()=>
        {
            guid = Guid.NewGuid();
            SystemGuid.FromNowOnReturn(guid);
        };

        Because of =()=> @event = new TestEvent();

        It should_set_its_Id =()=> @event.Id.ShouldEqual(guid);

        Cleanup after =()=> SystemGuid.FromNowOnGenerateNew();

        static Guid guid;
        static Event @event;

        private class TestEvent : Event
        {
        }
    }
}