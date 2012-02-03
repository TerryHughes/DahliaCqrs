namespace Dahlia.DataStore.ParticipantAssignedToRetreatEventHandlers.RetreatsWaitList
{
    using Data.Common;

    public class Version1 : ParticipantAssignedToRetreatEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [RetreatsWaitList] WHERE [RetreatId] = @RetreatId AND [ParticipantId] = @ParticipantId"; }
        }
    }
}
