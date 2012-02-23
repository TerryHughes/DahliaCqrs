namespace Dahlia.RelationalStore.ParticipantAssignedToRetreatEventHandlers.ParticipantsRetreats
{
    using Data.Common;

    public class Version1 : ParticipantAssignedToRetreatEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [ParticipantsRetreats] SET [Status] = 'Assigned' WHERE [RetreatId] = @RetreatId AND [ParticipantId] = @ParticipantId"; }
        }
    }
}
