namespace Dahlia.Testing.Extensions.ObjectExtensionSpecs
{
    using System;
    using Machine.Specifications;

    public class when_setting_the_value_of_a_non_public_instance_field
    {
        Establish context =()=>
        {
            value = "value";
            @class = new TestClass();
        };

        Because of =()=> @class.SetNonPublicInstanceField("value", value);

        It should_set_the_value =()=> @class.GetValue().ShouldEqual(value);

        static TestClass @class;
        static string value;

        class TestClass
        {
#pragma warning disable 649
            string value;
#pragma warning restore 649

            internal string GetValue()
            {
                return value;
            }
        }
    }
}
