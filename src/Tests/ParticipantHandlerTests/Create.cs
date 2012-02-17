/*
namespace Dahlia.ParticipantHandlerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.CommandHandlers;
    using Dahlia.Commands;
    using Dahlia.Events;

    public class Create : HandlerTestFixtureWithControlledGuid<CreateParticipantCommandHandler, CreateParticipantCommand>
    {
        private Guid guid = Guid.NewGuid();
        private string firstName = "firstName";
        private string lastName = "lastName";
        private DateTime dateRecieved = new DateTime(2011, 03, 23);

        protected override Guid ControlGuid
        {
            get { return guid; }
        }

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }

        protected override CreateParticipantCommandHandler WhenThisHandlerIsCalled()
        {
            return new CreateParticipantCommandHandler(EventStore);
        }

        protected override CreateParticipantCommand WithThisCommand()
        {
            return new CreateParticipantCommand(firstName, lastName, dateRecieved);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            yield return new Events.ParticipantCreatedEvent.Version1(firstName, lastName, dateRecieved) { AggregateRootId = guid };
        }
    }
}
*/
