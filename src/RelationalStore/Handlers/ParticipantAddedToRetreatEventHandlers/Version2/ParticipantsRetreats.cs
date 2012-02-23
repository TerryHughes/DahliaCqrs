namespace Dahlia.RelationalStore.ParticipantAddedToRetreatEventHandlers.ParticipantsRetreats
{
    using Data.Common;

    public class Version2 : ParticipantAddedToRetreatEventHandlers.Version2
    {
        public Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [ParticipantsRetreats] ([ParticipantId], [RetreatId], [Status]) VALUES (@ParticipantId, @RetreatId, 'Wait List')"; }
        }
    }
}
