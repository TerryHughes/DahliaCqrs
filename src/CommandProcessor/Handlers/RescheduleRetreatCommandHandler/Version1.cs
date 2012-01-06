namespace Dahlia.CommandProcessor.RescheduleRetreatCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentRescheduleRetreatCommand = Commands.RescheduleRetreatCommand.Version1;

    public class Version1 : CommandHandler<CurrentRescheduleRetreatCommand, Retreat>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentRescheduleRetreatCommand command, Retreat retreat)
        {
            retreat.Reschedule(command.Date);
        }
    }
}
