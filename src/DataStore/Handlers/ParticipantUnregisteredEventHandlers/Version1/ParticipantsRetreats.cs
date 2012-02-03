namespace Dahlia.DataStore.ParticipantUnregisteredEventHandlers.ParticipantsRetreats
{
    using Data.Common;

    public class Version1 : ParticipantUnregisteredEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [ParticipantsRetreats] WHERE [ParticipantId] = @Id"; }
        }
    }
}
