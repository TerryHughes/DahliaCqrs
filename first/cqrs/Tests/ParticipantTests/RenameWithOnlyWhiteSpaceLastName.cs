namespace Dahlia.ParticipantTests
{
    public class RenameWithOnlyWhiteSpaceLastName : RenameWithLastName
    {
        protected override string LastName
        {
            get { return "   "; }
        }
    }
}
