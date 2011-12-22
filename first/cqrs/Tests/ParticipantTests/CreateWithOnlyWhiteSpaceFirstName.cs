namespace Dahlia.ParticipantTests
{
    public class CreateWithOnlyWhiteSpaceFirstName : CreateWithFirstName
    {
        protected override string FirstName
        {
            get { return "   "; }
        }
    }
}
