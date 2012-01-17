namespace Dahlia.DataStore.ParticipantRenamedEventHandlers.ParticipantsAssignedToRetreat
{
    using Data.Common;

    public class Version1 : ParticipantRenamedEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [ParticipantsAssignedToRetreat] SET [ParticipantName] = @Name WHERE [ParticipantId] = @Id"; }
        }
    }
}
