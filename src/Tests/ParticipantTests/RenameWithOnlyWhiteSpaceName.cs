namespace Dahlia.Domain.ParticipantTests
{
    public class RenameWithOnlyWhiteSpaceName : RenameWithName
    {
        protected override string Name
        {
            get { return "   "; }
        }
    }
}
