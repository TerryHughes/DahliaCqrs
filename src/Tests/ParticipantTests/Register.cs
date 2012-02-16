namespace Dahlia.Domain.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public class Register : AggregateRootTestFixtureWithControlledGuid<Participant>
    {
        readonly Guid guid = Guid.NewGuid();
        readonly string name = "name";
        readonly DateTime dateRecieved = new DateTime(2011, 03, 23);

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
            SystemUnderTest.Register(name, null, dateRecieved);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            yield return new Events.ParticipantRegisteredEvent.Version2 { AggregateRootId = guid, Name = name, DateRecieved = dateRecieved };
        }
    }
}
