namespace Dahlia.DataStore.ParticipantRenamedEventHandlers.RetreatsWaitList
{
    using Data.Common;

    public class Version1 : ParticipantRenamedEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [RetreatsWaitList] SET [ParticipantName] = @Name WHERE [ParticipantId] = @Id"; }
        }
    }
}
