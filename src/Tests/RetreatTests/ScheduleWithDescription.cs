namespace Dahlia.Domain.RetreatTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public abstract class ScheduleWithDescription : AggregateRootTestFixtureWithControlledGuid<Retreat>
    {
        readonly Guid guid = Guid.NewGuid();
        readonly DateTime date = new DateTime(2011, 04, 04);

        protected abstract string Description { get; }

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
            SystemUnderTest.Schedule(date, Description);
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
