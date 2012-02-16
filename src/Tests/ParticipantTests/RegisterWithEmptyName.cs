namespace Dahlia.Domain.ParticipantTests
{
    using System;

    public class RegisterWithEmptyName : RegisterWithName
    {
        protected override string Name
        {
            get { return String.Empty; }
        }
    }
}
