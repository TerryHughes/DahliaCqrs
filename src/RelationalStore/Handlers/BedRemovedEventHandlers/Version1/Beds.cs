namespace Dahlia.RelationalStore.BedRemovedEventHandlers.Beds
{
    using Data.Common;

    public class Version1 : BedRemovedEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "DELETE FROM [Beds] WHERE [Id] = @Id"; }
        }
    }
}
