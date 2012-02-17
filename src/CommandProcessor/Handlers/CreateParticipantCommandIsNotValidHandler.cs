/*
namespace Dahlia.CommandHandlers
{
    using Dahlia.Commands;
    using Dahlia.Domain;
    using CurrentCreateParticipantFailedEvent = Events.CreateParticipantFailedEvent.Version1;

    public class CreateParticipantCommandIsNotValidHandler : Handler<CreateParticipantCommand>
    {
        private readonly Handler<CreateParticipantCommand> innerHandler;

        public CreateParticipantCommandIsNotValidHandler(Handler<CreateParticipantCommand> innerHandler)
        {
            this.innerHandler = innerHandler;
        }

        public void Handle(CreateParticipantCommand command)
        {
            try
            {
                innerHandler.Handle(command);
            }
            catch (IsNotValidException e)
            {
                new CurrentCreateParticipantFailedEvent(e.Message);
            }
        }
    }
}
*/
