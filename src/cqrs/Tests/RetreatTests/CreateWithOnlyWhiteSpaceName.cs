namespace Dahlia.RetreatTests
{
    public class CreateWithOnlyWhiteSpaceName : CreateWithName
    {
        protected override string Name
        {
            get { return "   "; }
        }
    }
}
