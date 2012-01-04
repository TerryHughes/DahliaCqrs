namespace Dahlia.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;

    public abstract class CreateWithFirstName : AggregateRootTestFixtureWithControlledGuid<Participant>
    {
        private Guid guid = Guid.NewGuid();
        private string lastName = "lastName";
        private DateTime dateRecieved = new DateTime(2011, 03, 23);

        protected abstract string FirstName { get; }

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
            SystemUnderTest.Create(FirstName, lastName, dateRecieved);
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
