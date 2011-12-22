namespace Dahlia.RetreatTests
{
    using System;

    public class CreateWithEmptyName : CreateWithName
    {
        protected override string Name
        {
            get { return String.Empty; }
        }
    }
}
