namespace Dahlia.RelationalStore.ParticipantAddedToRetreatEventHandlers.ParticipantsRetreats
{
    using Data.Common;

    public class Version1 : ParticipantAddedToRetreatEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [ParticipantsRetreats] ([ParticipantId], [RetreatId], [Status]) VALUES (@ParticipantId, @RetreatId, 'Wait List')"; }
        }
    }
}
