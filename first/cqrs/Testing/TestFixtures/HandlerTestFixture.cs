namespace Dahlia.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Commands;
    using Dahlia.Events;
    using Dahlia.EventStores;
    using NUnit.Framework;

    public abstract class HandlerTestFixture<THandler, TCommand> where THandler : Handler<TCommand> where TCommand : Command
    {
        private Exception caughtException;
        private IEnumerable<Event> addedEvents;

        protected TestEventStore EventStore { get; private set; }

        [SetUp]
        public void SetUp()
        {
            EventStore = new TestEventStore();
            foreach (var @event in GivenTheseEvents())
            {
                EventStore.EventsToLoad.Add(@event);
            }

            try
            {
                WhenThisHappens();
            }
            catch (Exception e)
            {
                caughtException = e;
            }
            finally
            {
                addedEvents = EventStore.AddedEvents;
            }
        }

        [Test]
        public void TheActualExceptionMatchesWhatWasExpected()
        {
            if (caughtException == null)
            {
                Assert.IsNull(ExpectThisException());
            }
            else
            {
                Assert.IsInstanceOf(ExpectThisException(), caughtException);
            }
        }

        [Test]
        public void TheActualEventsMatchWhatWasExpected()
        {
            Assert.IsTrue(ExpectTheseEvents().SequenceEqual(addedEvents, new EventComparer()));
        }

        protected virtual void WhenThisHappens()
        {
            var handler = WhenThisHandlerIsCalled();
            handler.Handle(WithThisCommand());
        }

        protected abstract IEnumerable<Event> GivenTheseEvents();
        protected abstract THandler WhenThisHandlerIsCalled();
        protected abstract TCommand WithThisCommand();
        protected abstract IEnumerable<Event> ExpectTheseEvents();

        protected virtual Type ExpectThisException()
        {
            return null;
        }
    }
}
