namespace Dahlia.ParticipantTests
{
    using System;

    public class RenameWithEmptyFirstName : RenameWithFirstName
    {
        protected override string FirstName
        {
            get { return String.Empty; }
        }
    }
}
