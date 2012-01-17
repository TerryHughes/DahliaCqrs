namespace Dahlia.DataStore.ParticipantAddedToRetreatEventHandlers.RetreatsParticipantIsAssignedTo
{
    using Data.Common;

    public class Version1 : ParticipantAddedToRetreatEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [RetreatsParticipantIsAssignedTo] ([ParticipantId], [RetreatId], [RetreatDate]) VALUES (@ParticipantId, @RetreatId, (SELECT [Date] FROM [Retreats] WHERE [Id] = @RetreatId))"; }
        }
    }
}
