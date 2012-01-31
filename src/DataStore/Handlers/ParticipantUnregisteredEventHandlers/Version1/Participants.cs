namespace Dahlia.DataStore.ParticipantUnregisteredEventHandlers.Participants
{
    using Data.Common;

    public class Version1 : ParticipantUnregisteredEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [Participants] WHERE [Id] = @Id"; }
        }
    }
}
