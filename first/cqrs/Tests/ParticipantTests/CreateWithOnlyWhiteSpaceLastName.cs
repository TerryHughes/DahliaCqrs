namespace Dahlia.ParticipantTests
{
    public class CreateWithOnlyWhiteSpaceLastName : CreateWithLastName
    {
        protected override string LastName
        {
            get { return "   "; }
        }
    }
}
