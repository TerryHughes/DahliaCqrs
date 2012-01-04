namespace Dahlia.ParticipantTests
{
    public class CreateWithNullFirstName : CreateWithFirstName
    {
        protected override string FirstName
        {
            get { return null; }
        }
    }
}
