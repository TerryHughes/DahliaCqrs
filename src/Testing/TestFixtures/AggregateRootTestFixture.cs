namespace Dahlia.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Events;
    using NUnit.Framework;

    public abstract class AggregateRootTestFixture<T> where T : AggregateRoot, new()
    {
        private Exception caughtException;
        private IEnumerable<Event> extractedEvents;

        protected T SystemUnderTest { get; private set; }

        [SetUp]
        public void SetUp()
        {
            SystemUnderTest = new T();
            SystemUnderTest.Load(GivenTheseEvents());

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
                extractedEvents = SystemUnderTest.ExtractEvents();
            }
        }

        [Test]
        public void TheActualExceptionMatchesWhatWasExpected()
        {
            if (ExpectThisException() == null)
            {
                Assert.IsNull(caughtException);
            }
            else
            {
                Assert.IsInstanceOf(ExpectThisException(), caughtException);
            }
        }

        [Test]
        public void TheActualEventsMatchWhatWasExpected()
        {
            Assert.IsTrue(ExpectTheseEvents().SequenceEqual(extractedEvents, new EventComparer()));
        }

        protected abstract IEnumerable<Event> GivenTheseEvents();
        protected abstract void WhenThisHappens();
        protected abstract IEnumerable<Event> ExpectTheseEvents();

        protected virtual Type ExpectThisException()
        {
            return null;
        }
    }
}
