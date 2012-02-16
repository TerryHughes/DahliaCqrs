namespace Dahlia.DataStore.ParticipantUnregisteredEventHandlers.Participants
{
    using Data.Common;

    public class Version3 : ParticipantUnregisteredEventHandlers.Version3
    {
        public Version3(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [Participants] WHERE [Id] = @Id"; }
        }
    }
}
