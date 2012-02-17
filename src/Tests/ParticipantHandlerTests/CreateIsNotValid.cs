/*
namespace Dahlia.ParticipantHandlerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Dahlia.CommandHandlers;
    using Dahlia.Commands;
    using Dahlia.Events;

    public class CreateIsNotValid : HandlerTestFixture<CreateParticipantCommandIsNotValidHandler, CreateParticipantCommand>
    {
        private string firstName = "firstName";
        private string lastName = "lastName";
        private DateTime dateRecieved = new DateTime(2011, 04, 20);

        protected override IEnumerable<Event> GivenTheseEvents()
        {
            return Enumerable.Empty<Event>();
        }

        protected override CreateParticipantCommandIsNotValidHandler WhenThisHandlerIsCalled()
        {
            return new CreateParticipantCommandIsNotValidHandler(new CreateParticipantCommandHandler(EventStore));
        }

        protected override CreateParticipantCommand WithThisCommand()
        {
            return new CreateParticipantCommand(firstName, lastName, dateRecieved);
        }

        protected override IEnumerable<Event> ExpectTheseEvents()
        {
            yield return new Events.CreateParticipantFailedEvent.Version1("reason");
        }
    }
}
*/
