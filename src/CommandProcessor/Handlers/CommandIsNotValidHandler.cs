namespace Dahlia.CommandProcessor
{
    using System;
    using NServiceBus;
    using Commands;
    using Domain;

    public class CommandIsNotValidHandler<TCommand> : IHandleMessages<TCommand>
        where TCommand : Command
    {
        readonly IHandleMessages<TCommand> handler;

        public CommandIsNotValidHandler(IHandleMessages<TCommand> handler)
        {
            this.handler = handler;
        }

        public IBus Bus { get; set; }

        public void Handle(TCommand command)
        {
            try
            {
                handler.Handle(command);
            }
            catch (IsNotValidException e)
            {
//                Bus.Publish(new CurrentCreateParticipantFailedEvent(e.Message));
            }
        }
    }
}
