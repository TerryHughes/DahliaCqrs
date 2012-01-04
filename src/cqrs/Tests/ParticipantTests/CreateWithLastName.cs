namespace Dahlia.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;

    public abstract class CreateWithLastName : AggregateRootTestFixtureWithControlledGuid<Participant>
    {
        private Guid guid = Guid.NewGuid();
        private string firstName = "firstName";
        private DateTime dateRecieved = new DateTime(2011, 04, 04);

        protected abstract string LastName { get; }

        protected override Guid ControlGuid
        {
            get { return guid; }
        }

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }

        protected override void WhenThisHappensWithControlledGuid()
        {
            SystemUnderTest.Create(firstName, LastName, dateRecieved);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }

        protected override Type ExpectThisException()
        {
            return typeof(IsNotValidException);
        }
    }
}
