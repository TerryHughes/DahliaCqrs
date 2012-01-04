namespace Dahlia.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;

    public class RenameToTheSame : AggregateRootTestFixture<Participant>
    {
        private string firstName = "firstName";
        private string lastName = "lastName";

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            yield return new Events.ParticipantCreatedEvent.Version1(firstName, lastName, new DateTime(2010, 04, 05)) { AggregateRootId = Guid.NewGuid() };
        }

        protected override void WhenThisHappens()
        {
            SystemUnderTest.Rename(firstName, lastName);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }
    }
}
