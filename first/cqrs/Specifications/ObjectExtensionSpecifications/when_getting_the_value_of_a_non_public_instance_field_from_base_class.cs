namespace Dahlia.ObjectExtensionSpecifications
{
    using System;
    using Machine.Specifications;

    public class when_getting_the_value_of_a_non_public_instance_field_from_base_class
    {
        Establish context =()=>
        {
            value = "value";
            @class = new TestClass();
            @class.SetValue(value);
        };

        Because of =()=> result = @class.GetNonPublicInstanceFieldFromBaseClass<string>(typeof(TestBaseClass), "value");

        It should_return_the_value =()=> result.ShouldEqual(value);

        static TestClass @class;
        static string value;
        static string result;

        private class TestClass : TestBaseClass
        {
        }

        private class TestBaseClass
        {
            private string value;

            internal void SetValue(string value)
            {
                this.value = value;
            }
        }
    }
}
