namespace Dahlia.ParticipantTests
{
    public class RenameWithNullLastName : RenameWithLastName
    {
        protected override string LastName
        {
            get { return null; }
        }
    }
}
