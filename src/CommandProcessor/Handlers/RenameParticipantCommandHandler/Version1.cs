namespace Dahlia.CommandProcessor.RenameParticipantCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentRenameParticipantCommand = Commands.RenameParticipantCommand.Version1;

    public class Version1 : CommandHandler<CurrentRenameParticipantCommand, Participant>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentRenameParticipantCommand command, Participant participant)
        {
            participant.Rename(command.Name);
        }
    }
}
