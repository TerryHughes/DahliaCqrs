namespace Dahlia.RetreatTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.Domain;
    using Dahlia.Events;

    public class Create : AggregateRootTestFixtureWithControlledGuid<Retreat>
    {
        private Guid guid = Guid.NewGuid();
        private string name = "name";
        private DateTime date = new DateTime(2011, 04, 04);

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
            SystemUnderTest.Create(name, date);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            yield return new Events.RetreatCreatedEvent.Version1(name, date) { AggregateRootId = guid };
        }
    }
}
