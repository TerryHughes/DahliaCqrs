namespace Dahlia.CommandProcessor.SnapshotParticipantCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCommand = Commands.SnapshotParticipantCommand.Version1;

    public class Version1 : CommandHandler<CurrentCommand, Participant>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCommand command, Participant participant)
        {
            participant.Snapshot();
        }
    }
}
