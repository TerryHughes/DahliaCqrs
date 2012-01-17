namespace Dahlia.DataStore.ParticipantUnregisteredEventHandlers.ParticipantsAssignedToRetreat
{
    using Data.Common;

    public class Version2 : ParticipantUnregisteredEventHandlers.Version2
    {
        public Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [ParticipantsAssignedToRetreat] WHERE [ParticipantId] = @Id"; }
        }
    }
}
