namespace Dahlia.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using Dahlia.Domain;
    using Dahlia.Events;

    public class Rename : AggregateRootTestFixture<Participant>
    {
        private Guid id = Guid.NewGuid();
        private string firstName = "firstName";
        private string lastName = "lastName";

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            yield return new Events.ParticipantCreatedEvent.Version1("fName", "lName", new DateTime(2010, 04, 05)) { AggregateRootId = id };
        }

        protected override void WhenThisHappens()
        {
            SystemUnderTest.Rename(firstName, lastName);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            yield return new Events.ParticipantRenamedEvent.Version1(firstName, lastName) { AggregateRootId = id };
        }
    }
}
