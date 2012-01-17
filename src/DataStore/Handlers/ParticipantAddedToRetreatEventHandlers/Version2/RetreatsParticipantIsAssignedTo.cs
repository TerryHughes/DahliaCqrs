namespace Dahlia.DataStore.ParticipantAddedToRetreatEventHandlers.RetreatsParticipantIsAssignedTo
{
    using Data.Common;

    public class Version2 : ParticipantAddedToRetreatEventHandlers.Version2
    {
        public Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [RetreatsParticipantIsAssignedTo] ([ParticipantId], [RetreatId], [RetreatDate]) VALUES (@ParticipantId, @RetreatId, @RetreatDate)"; }
        }
    }
}
