namespace Dahlia.CommandHandlers
{
    using System;
    using NServiceBus;
    using CreateRetreatCommand = Dahlia.Commands.CreateRetreatCommand.Version1;
    using RetreatCreatedEvent = Dahlia.Events.RetreatCreatedEvent.Version1;

    public class CreateRetreatCommandHandler : IHandleMessages<CreateRetreatCommand>
    {
        public IBus Bus { get; set; }

        public void Handle(CreateRetreatCommand command)
        {
            var guid = Guid.NewGuid();
            Bus.Publish(new RetreatCreatedEvent(guid, command.Date, command.Description) { CommandId = command.Id });
        }
    }
}
