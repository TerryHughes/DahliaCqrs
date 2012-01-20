namespace Dahlia.DataStore.RetreatRescheduledEventHandlers.RetreatsParticipantIsAssignedTo
{
    using Data.Common;

    public class Version1 : RetreatRescheduledEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [RetreatsParticipantIsAssignedTo] SET [RetreatDate] = @Date WHERE [RetreatId] = @Id"; }
        }
    }
}
