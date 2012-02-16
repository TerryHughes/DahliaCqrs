namespace Dahlia.Domain.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public class RenameToTheSame : AggregateRootTestFixture<Participant>
    {
        readonly string name = "name";

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            yield return new Events.ParticipantRegisteredEvent.Version2 { AggregateRootId = Guid.NewGuid(), Name = name, DateRecieved = new DateTime(2010, 04, 05) };
        }

        protected override void WhenThisHappens()
        {
            SystemUnderTest.Rename(name);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }
    }
}
