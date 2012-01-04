namespace Dahlia.ParticipantTests
{
    using System;

    public class CreateWithEmptyFirstName : CreateWithFirstName
    {
        protected override string FirstName
        {
            get { return String.Empty; }
        }
    }
}
