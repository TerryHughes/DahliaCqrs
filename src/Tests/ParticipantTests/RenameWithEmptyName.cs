namespace Dahlia.Domain.ParticipantTests
{
    using System;

    public class RenameWithEmptyName : RenameWithName
    {
        protected override string Name
        {
            get { return String.Empty; }
        }
    }
}
