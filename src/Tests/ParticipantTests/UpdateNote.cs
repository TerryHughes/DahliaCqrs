/*
namespace Dahlia.Domain.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using Events;

    public class UpdateNote : AggregateRootTestFixture<Participant>
    {
        readonly Guid id = Guid.NewGuid();
        readonly string note = "note";

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            yield return new Events.ParticipantRegisteredEvent.Version2 { AggregateRootId = id, Name = "name", DateRecieved = new DateTime(2010, 04, 05) };
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
*/
