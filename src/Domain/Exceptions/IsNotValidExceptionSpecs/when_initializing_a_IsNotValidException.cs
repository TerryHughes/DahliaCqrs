namespace Dahlia.Domain.IsNotValidExceptionSpecs
{
    using Machine.Specifications;

    public class when_initializing_a_IsNotValidException
    {
        Establish context =()=>
        {
            whatIsNotValid = "whatIsNotValid";
            whyItIsNotValid = "whyItIsNotValid";
        };

        Because of =()=> exception = new IsNotValidException(whatIsNotValid, whyItIsNotValid);

        It should_have_a_useful_message =()=> exception.Message.ShouldEqual(whatIsNotValid + " is not valid: " + whyItIsNotValid);

        static string whatIsNotValid;
        static string whyItIsNotValid;
        static IsNotValidException exception;
    }
}
