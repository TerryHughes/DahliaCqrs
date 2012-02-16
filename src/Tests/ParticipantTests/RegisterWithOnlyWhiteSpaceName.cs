namespace Dahlia.Domain.ParticipantTests
{
    public class RegisterWithOnlyWhiteSpaceName : RegisterWithName
    {
        protected override string Name
        {
            get { return "   "; }
        }
    }
}
