namespace Dahlia.DataStore.ParticipantUnassignedFromRetreatEventHandlers.RetreatsAssigned
{
    using Data.Common;

    public class Version1 : ParticipantUnassignedFromRetreatEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [RetreatsAssigned] WHERE [RetreatId] = @RetreatId AND [ParticipantId] = @ParticipantId"; }
        }
    }
}
