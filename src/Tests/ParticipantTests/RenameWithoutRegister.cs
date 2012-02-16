namespace Dahlia.Domain.ParticipantTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public class RenameWithoutRegister : AggregateRootTestFixture<Participant>
    {
        protected override IEnumerable<Event> GivenTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }

        protected override void WhenThisHappens()
        {
            SystemUnderTest.Rename("name");
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
