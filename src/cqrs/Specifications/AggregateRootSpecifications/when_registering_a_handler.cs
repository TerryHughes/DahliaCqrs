namespace Dahlia.AggregateRootSpecifications
{
    using System;
    using System.Collections.Generic;
    using Dahlia.Domain;
    using Dahlia.Events;
    using Dahlia.Events.RegisterHandlerEvents;
    using Machine.Specifications;

    public class when_registering_a_handler
    {
        Establish context =()=> aggregateRoot = new TestAggregateRoot();

        Because of =()=> aggregateRoot.CallRegisterHandler<TestEvent>(e => executed = true);

        It should_remember_what_handlers_were_registered =()=> aggregateRoot.GetNonPublicInstanceFieldFromBaseClass<IDictionary<Type, Action<Event>>>(typeof(AggregateRoot), "handlers").Count.ShouldEqual(2);

        It should_be_able_to_execute_the_handler =()=>
        {
            aggregateRoot.GetNonPublicInstanceFieldFromBaseClass<IDictionary<Type, Action<Event>>>(typeof(AggregateRoot), "handlers")[typeof(TestEvent)](new TestEvent());

            executed.ShouldBeTrue();
        };

        static TestAggregateRoot aggregateRoot;
        static bool executed;

        private class TestAggregateRoot : AggregateRoot
        {
            internal void CallRegisterHandler<T>(Action<T> handler) where T : Event
            {
                RegisterHandler(handler);
            }
        }
    }
}

namespace Dahlia.Events.RegisterHandlerEvents
{
    internal class TestEvent : Event
    {
    }

    internal class OtherTestEvent : Event
    {
    }

    internal class NonEvent
    {
    }
}
