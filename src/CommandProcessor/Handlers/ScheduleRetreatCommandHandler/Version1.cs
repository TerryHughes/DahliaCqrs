namespace Dahlia.CommandProcessor.ScheduleRetreatCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentScheduleRetreatCommand = Commands.ScheduleRetreatCommand.Version1;

    public class Version1 : CommandHandlerWithEmptyGuid<CurrentScheduleRetreatCommand, Retreat>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentScheduleRetreatCommand command, Retreat retreat)
        {
            retreat.Schedule(command.Date, command.Description);
        }
    }
}
