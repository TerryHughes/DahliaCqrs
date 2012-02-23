namespace Dahlia.RelationalStore.RetreatRenamedEventHandlers.Retreats
{
    using Data.Common;

    public class Version1 : RetreatRenamedEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [Retreats] SET [Description] = @Description WHERE [Id] = @Id"; }
        }
    }
}
