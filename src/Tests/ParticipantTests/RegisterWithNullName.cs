namespace Dahlia.Domain.ParticipantTests
{
    public class RegisterWithNullName : RegisterWithName
    {
        protected override string Name
        {
            get { return null; }
        }
    }
}
