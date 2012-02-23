namespace Dahlia.RelationalStore.RetreatRescheduledEventHandlers.Retreats
{
    using Data.Common;

    public class Version1 : RetreatRescheduledEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [Retreats] SET [Date] = @Date WHERE [Id] = @Id"; }
        }
    }
}
