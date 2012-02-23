namespace Dahlia.RelationalStore.ParticipantUnregisteredEventHandlers.ParticipantsRetreats
{
    using Data.Common;

    public class Version3 : ParticipantUnregisteredEventHandlers.Version3
    {
        public Version3(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [ParticipantsRetreats] WHERE [ParticipantId] = @Id"; }
        }
    }
}
