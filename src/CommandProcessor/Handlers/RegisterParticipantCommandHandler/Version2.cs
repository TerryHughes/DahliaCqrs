namespace Dahlia.CommandProcessor.RegisterParticipantCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCommand = Commands.RegisterParticipantCommand.Version2;

    public class Version2 : CommandHandlerWithEmptyGuid<CurrentCommand, Participant>
    {
        public Version2(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCommand command, Participant participant)
        {
            participant.Register(command.Name, command.Note, command.DateRecieved);
        }
    }
}
