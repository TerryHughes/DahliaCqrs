namespace Dahlia.ParticipantTests
{
    public class RenameWithOnlyWhiteSpaceFirstName : RenameWithFirstName
    {
        protected override string FirstName
        {
            get { return "   "; }
        }
    }
}
