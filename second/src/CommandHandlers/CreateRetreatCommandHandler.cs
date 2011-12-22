namespace Dahlia.CommandHandlers
{
    using System;
    using NServiceBus;
    using PreviousCreateRetreatCommand = Dahlia.Commands.CreateRetreatCommand.Version1;
    using CurrentCreateRetreatCommand = Dahlia.Commands.CreateRetreatCommand.Version2;
    using PreviousRetreatCreatedEvent = Dahlia.Events.RetreatCreatedEvent.Version1;
    using CurrentRetreatCreatedEvent = Dahlia.Events.RetreatCreatedEvent.Version2;

    public class CreateRetreatCommandHandler : IHandleMessages<PreviousCreateRetreatCommand>, IHandleMessages<CurrentCreateRetreatCommand>
    {
        public IBus Bus { get; set; }

        public void Handle(PreviousCreateRetreatCommand command)
        {
            var guid = Guid.NewGuid();
if (command.Description.StartsWith("kick your knees up "))
System.Threading.Thread.Sleep(2500);
            Bus.Publish(new PreviousRetreatCreatedEvent(guid, command.Date, command.Description) { CommandId = command.Id });
        }

        public void Handle(CurrentCreateRetreatCommand command)
        {
            var guid = Guid.NewGuid();
            Bus.Publish(new CurrentRetreatCreatedEvent(guid, command.Date, command.Description) { CommandId = command.Id });
        }
    }
}
