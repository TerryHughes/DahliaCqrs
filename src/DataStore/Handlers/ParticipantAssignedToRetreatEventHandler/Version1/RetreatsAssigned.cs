namespace Dahlia.DataStore.ParticipantAssignedToRetreatEventHandlers.RetreatsAssigned
{
    using Data.Common;

    public class Version1 : ParticipantAssignedToRetreatEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [RetreatsAssigned] ([RetreatId], [ParticipantId], [ParticipantName], [BedId], [BedName]) VALUES (@RetreatId, @ParticipantId, @ParticipantName, @BedId, @BedName)"; }
        }
    }
}
