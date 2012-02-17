namespace Dahlia.Testing.Extensions.ObjectExtensionSpecs
{
    using System;
    using Machine.Specifications;

    public class when_invoking_a_non_public_instance_method_that_is_an_action
    {
        Establish context =()=>
        {
            input = "input";

            @class = new TestClass();
        };

        Because of =()=> @class.InvokeNonPublicInstanceMethod("Method", new[] { input });

        It should_pass_along_the_parameter =()=> @class.Input.ShouldEqual(input);

        static string input;
        static TestClass @class;

        class TestClass
        {
            internal string Input;

            protected void Method(string input)
            {
                Input = input;
            }
        }
    }
}
