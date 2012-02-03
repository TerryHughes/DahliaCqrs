namespace Dahlia.DataStore.ParticipantAddedToRetreatEventHandlers.RetreatsWaitList
{
    using Data.Common;

    public class Version1 : ParticipantAddedToRetreatEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [RetreatsWaitList] ([RetreatId], [ParticipantId], [ParticipantName]) VALUES (@RetreatId, @ParticipantId, (SELECT [Name] FROM [Participants] WHERE [Id] = @ParticipantId))"; }
        }
    }
}
