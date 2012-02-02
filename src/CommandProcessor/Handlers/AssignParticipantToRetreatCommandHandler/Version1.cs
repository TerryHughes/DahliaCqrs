namespace Dahlia.CommandProcessor.AssignParticipantToRetreatCommandHandler
{
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCommand = Commands.AssignParticipantToRetreatCommand.Version1;

    public class Version1 : CommandHandler<CurrentCommand, Retreat>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCommand command, Retreat retreat)
        {
            retreat.Assign(command.ParticipantId, command.BedId);
        }
    }
}
