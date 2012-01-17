namespace Dahlia.CommandProcessor.AddParticipantToRetreatCommandHandler
{
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCommand = Commands.AddParticipantToRetreatCommand.Version1;

    public class Version1 : CommandHandler<CurrentCommand, Retreat>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCommand command, Retreat retreat)
        {
            retreat.Add(command.ParticipantId);
        }
    }
}
