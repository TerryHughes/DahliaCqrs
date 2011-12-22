namespace Dahlia.ParticipantTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;

    public class RenameWithoutCreate : AggregateRootTestFixture<Participant>
    {
        protected override IEnumerable<Event> GivenTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }

        protected override void WhenThisHappens()
        {
            SystemUnderTest.Rename("firstName", "lastName");
        }

        protected override System.Type ExpectThisException()
        {
            return typeof(AggregateRootNotCreatedException);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }
    }
}
