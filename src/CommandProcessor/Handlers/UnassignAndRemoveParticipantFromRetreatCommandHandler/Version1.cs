namespace Dahlia.CommandProcessor.UnassignAndRemoveParticipantFromRetreatCommandHandler
{
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCommand = Commands.UnassignAndRemoveParticipantFromRetreatCommand.Version1;

    public class Version1 : CommandHandler<CurrentCommand, Retreat>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCommand command, Retreat retreat)
        {
            retreat.Unassign(command.ParticipantId);
            retreat.Remove(command.ParticipantId);
        }
    }
}
