namespace Dahlia.CommandProcessor.RegisterParticipantCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCommand = Commands.RegisterParticipantCommand.Version1;

    public class Version1 : CommandHandlerWithEmptyGuid<CurrentCommand, Participant>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCommand command, Participant participant)
        {
            participant.Register(command.Name, command.Note);
        }
    }
}
