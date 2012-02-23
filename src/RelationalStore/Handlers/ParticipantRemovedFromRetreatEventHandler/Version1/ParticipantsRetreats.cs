namespace Dahlia.RelationalStore.ParticipantRemovedFromRetreatEventHandlers.ParticipantsRetreats
{
    using Data.Common;

    public class Version2 : ParticipantRemovedFromRetreatEventHandlers.Version1
    {
        public Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [ParticipantsRetreats] WHERE [ParticipantId] = @ParticipantId AND [RetreatId] = @RetreatId"; }
        }
    }
}
