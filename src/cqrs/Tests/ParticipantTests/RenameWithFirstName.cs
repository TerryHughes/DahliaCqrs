namespace Dahlia.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;

    public abstract class RenameWithFirstName : AggregateRootTestFixture<Participant>
    {
        private Guid id = Guid.NewGuid();
        private string lName = "lName";

        protected abstract string FirstName { get; }

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            yield return new Events.ParticipantCreatedEvent.Version1("fName", lName, new DateTime(2011, 04, 05)) { AggregateRootId = id };
        }

        protected override void WhenThisHappens()
        {
            SystemUnderTest.Rename(FirstName, lName);
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
