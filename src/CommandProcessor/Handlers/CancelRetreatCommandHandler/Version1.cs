namespace Dahlia.CommandProcessor.CancelRetreatCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCancelRetreatCommand = Commands.CancelRetreatCommand.Version1;

    public class Version1 : CommandHandler<CurrentCancelRetreatCommand, Retreat>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCancelRetreatCommand command, Retreat retreat)
        {
            retreat.Cancel();
        }
    }
}
