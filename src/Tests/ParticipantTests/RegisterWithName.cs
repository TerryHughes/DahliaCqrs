namespace Dahlia.Domain.ParticipantTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public abstract class RegisterWithName : AggregateRootTestFixtureWithControlledGuid<Participant>
    {
        readonly Guid guid = Guid.NewGuid();
        readonly DateTime dateRecieved = new DateTime(2011, 03, 23);

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
            SystemUnderTest.Register(Name, null, dateRecieved);
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
