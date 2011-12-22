namespace Dahlia.ParticipantTests
{
    using System;

    public class RenameWithEmptyLastName : RenameWithLastName
    {
        protected override string LastName
        {
            get { return String.Empty; }
        }
    }
}
