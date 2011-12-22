namespace Dahlia.RetreatTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;

    public abstract class CreateWithName : AggregateRootTestFixtureWithControlledGuid<Retreat>
    {
        private Guid guid = Guid.NewGuid();
        private DateTime date = new DateTime(2011, 04, 04);

        protected abstract string Name { get; }

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
            SystemUnderTest.Create(Name, date);
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
