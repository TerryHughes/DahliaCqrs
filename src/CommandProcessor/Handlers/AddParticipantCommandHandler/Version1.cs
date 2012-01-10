namespace Dahlia.CommandProcessor.AddParticipantCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentAddParticipantCommand = Commands.AddParticipantCommand.Version1;

    public class Version1 : CommandHandlerWithEmptyGuid<CurrentAddParticipantCommand, Participant>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentAddParticipantCommand command, Participant participant)
        {
            participant.Create(command.Name, command.Note);
        }
    }
}
