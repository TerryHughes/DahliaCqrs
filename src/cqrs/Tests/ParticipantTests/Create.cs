namespace Dahlia.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;

    public class Create : AggregateRootTestFixtureWithControlledGuid<Participant>
    {
        private Guid guid = Guid.NewGuid();
        private string firstName = "firstName";
        private string lastName = "lastName";
        private DateTime dateRecieved = new DateTime(2011, 03, 23);

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
            SystemUnderTest.Create(firstName, lastName, dateRecieved);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            yield return new Events.ParticipantCreatedEvent.Version1(firstName, lastName, dateRecieved) { AggregateRootId = guid };
        }
    }
}
