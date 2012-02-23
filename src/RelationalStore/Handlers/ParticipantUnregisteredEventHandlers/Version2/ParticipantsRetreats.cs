namespace Dahlia.RelationalStore.ParticipantUnregisteredEventHandlers.ParticipantsRetreats
{
    using Data.Common;

    public class Version2 : ParticipantUnregisteredEventHandlers.Version2
    {
        public Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [ParticipantsRetreats] WHERE [ParticipantId] = @Id"; }
        }
    }
}
