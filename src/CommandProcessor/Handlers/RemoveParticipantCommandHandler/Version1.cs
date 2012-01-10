namespace Dahlia.CommandProcessor.RemoveParticipantCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCommand = Commands.RemoveParticipantCommand.Version1;

    public class Version1 : CommandHandler<CurrentCommand, Participant>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCommand command, Participant participant)
        {
            participant.Remove();
        }
    }
}
