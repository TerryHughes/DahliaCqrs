namespace Dahlia.DataStore.RetreatScheduledEventHandlers.Retreats
{
    using Data.Common;

    public class Version1 : RetreatScheduledEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [Retreats] ([Id], [Date], [Description]) VALUES (@Id, @Date, @Description)"; }
        }
    }
}
