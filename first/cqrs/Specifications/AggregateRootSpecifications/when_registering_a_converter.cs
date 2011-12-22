namespace Dahlia.AggregateRootSpecifications
{
    using System;
    using System.Collections.Generic;
    using Dahlia.Domain;
    using Dahlia.Events;
    using Machine.Specifications;

    public class when_registering_a_converter
    {
        Establish context =()=> aggregateRoot = new TestAggregateRoot();

        Because of =()=> aggregateRoot.CallRegisterConverter<TestEvent, TestEvent>(e => new TestEvent());

        It should_remember_what_converters_were_registered =()=> aggregateRoot.GetNonPublicInstanceFieldFromBaseClass<IDictionary<Type, Func<Event, Event>>>(typeof(AggregateRoot), "converters").Count.ShouldEqual(1);

        It should_be_able_to_execute_the_converter =()=> aggregateRoot.GetNonPublicInstanceFieldFromBaseClass<IDictionary<Type, Func<Event, Event>>>(typeof(AggregateRoot), "converters")[typeof(TestEvent)](null).ShouldNotBeNull();

        static TestAggregateRoot aggregateRoot;

        private class TestAggregateRoot : AggregateRoot
        {
            internal void CallRegisterConverter<TInput, TOutput>(Func<TInput, TOutput> converter) where TInput : Event where TOutput : Event
            {
                RegisterConverter(converter);
            }
        }

        private class TestEvent : Event
        {
        }
    }
}
