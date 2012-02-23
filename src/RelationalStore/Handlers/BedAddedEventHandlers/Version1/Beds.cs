namespace Dahlia.RelationalStore.BedAddedEventHandlers.Beds
{
    using Data.Common;

    public class Version1 : BedAddedEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [Beds] ([Id], [Name]) VALUES (@Id, @Name)"; }
        }
    }
}
