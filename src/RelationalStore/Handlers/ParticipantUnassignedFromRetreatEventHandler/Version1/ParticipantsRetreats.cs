namespace Dahlia.RelationalStore.ParticipantUnassignedFromRetreatEventHandlers.ParticipantsRetreats
{
    using Data.Common;

    public class Version1 : ParticipantUnassignedFromRetreatEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [ParticipantsRetreats] SET [Status] = 'Wait List' WHERE [RetreatId] = @RetreatId AND [ParticipantId] = @ParticipantId"; }
        }
    }
}
