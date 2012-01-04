namespace Dahlia.ObjectExtensionSpecifications
{
    using System;
    using Machine.Specifications;

    public class when_invoking_a_non_public_instance_method_that_is_a_func
    {
        Establish context =()=>
        {
            input = "input";
            output = "output";

            @class = new TestClass();
        };

        Because of =()=> result = @class.InvokeNonPublicInstanceMethod<string>("Method", new[] { input });

        It should_pass_along_the_parameter =()=> @class.Input.ShouldEqual(input);

        It should_return_the_value =()=> result.ShouldEqual(output);

        static string input;
        static string output;
        static TestClass @class;
        static string result;

        private class TestClass
        {
            internal string Input;

            protected string Method(string input)
            {
                Input = input;

                return output;
            }
        }
    }
}
