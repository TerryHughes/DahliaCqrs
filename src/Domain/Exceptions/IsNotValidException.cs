namespace Dahlia.Domain
{
    using System;

    public class IsNotValidException : Exception
    {
        public IsNotValidException(string whatIsNotValid, string whyItIsNotValid) : base(String.Format("{0} is not valid: {1}", whatIsNotValid, whyItIsNotValid))
        {
        }
    }
}
