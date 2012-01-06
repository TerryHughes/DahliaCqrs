namespace Dahlia.CommandProcessor.RenameRetreatCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentRenameRetreatCommand = Commands.RenameRetreatCommand.Version1;

    public class Version1 : CommandHandler<CurrentRenameRetreatCommand, Retreat>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentRenameRetreatCommand command, Retreat retreat)
        {
            retreat.Rename(command.Description);
        }
    }
}
