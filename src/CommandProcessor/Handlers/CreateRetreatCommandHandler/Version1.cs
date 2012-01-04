namespace Dahlia.CommandProcessor.CreateRetreatCommandHandler
{
    using System;
    using NServiceBus;
    using Domain;
    using EventStores;
    using CurrentCreateRetreatCommand = Commands.CreateRetreatCommand.Version1;

    public class Version1 : CommandHandlerWithEmptyGuid<CurrentCreateRetreatCommand, Retreat>
    {
        public Version1(EventStore eventStore, IBus bus) : base(eventStore, bus)
        {
        }

        protected override void Action(CurrentCreateRetreatCommand command, Retreat retreat)
        {
            retreat.Create(command.Date, command.Description);
        }
    }
}
