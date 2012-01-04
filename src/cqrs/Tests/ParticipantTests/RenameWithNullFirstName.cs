namespace Dahlia.ParticipantTests
{
    public class RenameWithNullFirstName : RenameWithFirstName
    {
        protected override string FirstName
        {
            get { return null; }
        }
    }
}
