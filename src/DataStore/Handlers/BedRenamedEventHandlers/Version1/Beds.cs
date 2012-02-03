namespace Dahlia.DataStore.BedRenamedEventHandlers.Beds
{
    using Data.Common;

    public class Version1 : BedRenamedEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "UPDATE [Beds] SET [Name] = @Name WHERE [Id] = @Id"; }
        }
    }
}
