namespace Dahlia.DataStore.ParticipantUnregisteredEventHandlers.RetreatsParticipantIsAssignedTo
{
    using Data.Common;

    public class Version1 : ParticipantUnregisteredEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [RetreatsParticipantIsAssignedTo] WHERE [RetreatId] = @Id"; }
        }
    }
}
