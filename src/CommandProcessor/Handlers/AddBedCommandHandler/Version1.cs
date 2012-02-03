namespace Dahlia.CommandProcessor.AddBedCommandHandler
{
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCommand = Commands.AddBedCommand.Version1;

    public class Version1 : CommandHandler<CurrentCommand, Bed>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCommand command, Bed bed)
        {
            bed.Add(command.Name);
        }
    }
}
