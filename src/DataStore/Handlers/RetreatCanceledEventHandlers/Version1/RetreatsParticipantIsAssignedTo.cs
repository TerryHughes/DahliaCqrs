namespace Dahlia.DataStore.RetreatCanceledEventhandlers.RetreatsParticipantIsAssignedTo
{
    using Data.Common;

    public class Version1 : RetreatCanceledEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [RetreatsParticipantIsAssignedTo] WHERE [RetreatId] = @Id"; }
        }
    }
}
