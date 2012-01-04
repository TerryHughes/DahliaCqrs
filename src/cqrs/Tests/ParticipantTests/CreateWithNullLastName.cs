namespace Dahlia.ParticipantTests
{
    public class CreateWithNullLastName : CreateWithLastName
    {
        protected override string LastName
        {
            get { return null; }
        }
    }
}
