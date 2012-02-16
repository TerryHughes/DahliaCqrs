namespace Dahlia.Domain.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using Events;

    public class Rename : AggregateRootTestFixture<Participant>
    {
        readonly Guid id = Guid.NewGuid();
        readonly string name = "rename";

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            yield return new Events.ParticipantRegisteredEvent.Version2 { AggregateRootId = id, Name = "name", DateRecieved = new DateTime(2010, 04, 05) };
        }

        protected override void WhenThisHappens()
        {
            SystemUnderTest.Rename(name);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            yield return new Events.ParticipantRenamedEvent.Version1 { AggregateRootId = id, Name = name };
        }
    }
}
