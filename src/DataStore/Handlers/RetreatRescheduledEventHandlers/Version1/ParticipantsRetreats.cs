namespace Dahlia.DataStore.RetreatRescheduledEventHandlers.ParticipantsRetreats
{
    using Data.Common;

    public class Version1 : RetreatRescheduledEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [ParticipantsRetreats] SET [RetreatDate] = @Date WHERE [RetreatId] = @Id"; }
        }
    }
}
