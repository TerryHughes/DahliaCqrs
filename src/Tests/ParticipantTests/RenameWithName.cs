namespace Dahlia.Domain.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public abstract class RenameWithName : AggregateRootTestFixture<Participant>
    {
        readonly Guid id = Guid.NewGuid();

        protected abstract string Name { get; }

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            yield return new Events.ParticipantRegisteredEvent.Version2 { AggregateRootId = id, Name = "name", DateRecieved = new DateTime(2011, 04, 05) };
        }

        protected override void WhenThisHappens()
        {
            SystemUnderTest.Rename(Name);
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
