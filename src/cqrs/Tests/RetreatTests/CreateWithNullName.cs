namespace Dahlia.RetreatTests
{
    public class CreateWithNullName : CreateWithName
    {
        protected override string Name
        {
            get { return null; }
        }
    }
}
