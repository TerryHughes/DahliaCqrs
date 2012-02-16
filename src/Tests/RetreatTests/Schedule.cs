namespace Dahlia.Domain.RetreatTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public class Schedule : AggregateRootTestFixtureWithControlledGuid<Retreat>
    {
        readonly Guid guid = Guid.NewGuid();
        readonly DateTime date = new DateTime(2011, 04, 04);
        readonly string description = "description";

        protected override Guid ControlGuid
        {
            get { return guid; }
        }

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }

        protected override void WhenThisHappensWithControlledGuid()
        {
            SystemUnderTest.Schedule(date, description);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            yield return new Events.RetreatScheduledEvent.Version1 { AggregateRootId = guid, Date = date, Description = description };
        }
    }
}
