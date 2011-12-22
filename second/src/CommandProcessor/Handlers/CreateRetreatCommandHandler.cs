namespace Dahlia.CommandProcessor
{
    using System;
    using NServiceBus;
    using CurrentCreateRetreatCommand = Commands.CreateRetreatCommand.Version1;
    using CurrentRetreatCreatedEvent = Events.RetreatCreatedEvent.Version1;

    public class CreateRetreatCommandHandler : IHandleMessages<CurrentCreateRetreatCommand>
    {
        public IBus Bus { get; set; }

        public void Handle(CurrentCreateRetreatCommand command)
        {
            var guid = Guid.NewGuid();
            Bus.Publish(new CurrentRetreatCreatedEvent { AggregateRootId = guid, Date = command.Date, Description = command.Description });
        }
    }
}
