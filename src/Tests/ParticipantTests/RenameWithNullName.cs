namespace Dahlia.Domain.ParticipantTests
{
    public class RenameWithNullName : RenameWithName
    {
        protected override string Name
        {
            get { return null; }
        }
    }
}
