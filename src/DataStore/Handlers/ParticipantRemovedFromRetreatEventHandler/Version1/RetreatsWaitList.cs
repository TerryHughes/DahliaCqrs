namespace Dahlia.DataStore.ParticipantRemovedFromRetreatEventHandlers.RetreatsWaitList
{
    using Data.Common;

    public class Version2 : ParticipantRemovedFromRetreatEventHandlers.Version1
    {
        public Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [RetreatsWaitList] WHERE [RetreatId] = @RetreatId AND [ParticipantId] = @ParticipantId"; }
        }
    }
}
