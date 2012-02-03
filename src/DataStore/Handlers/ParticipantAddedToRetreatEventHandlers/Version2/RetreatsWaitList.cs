namespace Dahlia.DataStore.ParticipantAddedToRetreatEventHandlers.RetreatsWaitList
{
    using Data.Common;

    public class Version2 : ParticipantAddedToRetreatEventHandlers.Version2
    {
        public Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [RetreatsWaitList] ([RetreatId], [ParticipantId], [ParticipantName]) VALUES (@RetreatId, @ParticipantId, @ParticipantName)"; }
        }
    }
}
