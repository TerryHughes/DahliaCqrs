namespace Dahlia.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using Dahlia.Domain;
    using Dahlia.Events;

    public class UpdateNote : AggregateRootTestFixture<Participant>
    {
        private Guid id = Guid.NewGuid();
        private string note = "note";

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            yield return new Events.ParticipantCreatedEvent.Version1("firstName", "lastName", new DateTime(2010, 04, 05)) { AggregateRootId = id };
        }

        protected override void WhenThisHappens()
        {
            SystemUnderTest.Update(note);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            yield return new Events.ParticipantNoteUpdatedEvent.Version1(note) { AggregateRootId = id };
        }
    }
}
