namespace Dahlia.ParticipantTests
{
    using System;

    public class CreateWithEmptyLastName : CreateWithLastName
    {
        protected override string LastName
        {
            get { return String.Empty; }
        }
    }
}
