namespace Dahlia.DataStore.ParticipantRenamedEventhandlers.Participants
{
    using Data.Common;

    public class Version1 : ParticipantRenamedEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [Participants] SET [Name] = @Name WHERE [Id] = @Id"; }
        }
    }
}
