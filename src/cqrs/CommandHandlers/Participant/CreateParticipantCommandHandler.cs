namespace Dahlia.CommandHandlers
{
    using Dahlia.Commands;
    using Dahlia.Domain;
    using Dahlia.EventStores;

    public class CreateParticipantCommandHandler : CommandHandlerWithEmptyGuid<CreateParticipantCommand, Participant>
    {
        public CreateParticipantCommandHandler(EventStore eventStore) : base(eventStore)
        {
        }

        protected override void Action(CreateParticipantCommand command, Participant p)
        {
            p.Create(command.FirstName, command.LastName, command.DateRecieved);
        }
    }
}
