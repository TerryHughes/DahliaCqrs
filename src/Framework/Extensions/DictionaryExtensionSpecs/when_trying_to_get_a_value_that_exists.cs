namespace Dahlia.Framework.DictionaryExtensionSpecs
{
    using System.Collections.Generic;
    using Machine.Specifications;

    public class when_trying_to_get_a_value_that_exists
    {
        Establish context =()=>
        {
            key = 1;
            value = "one";
            dictionary = new Dictionary<int, string> { { key, value } };
        };

        Because of =()=> @try = dictionary.TryGetValue(key);

        It should_have_succeeded =()=> @try.Succeeded.ShouldBeTrue();

        It should_have_a_value =()=> @try.Value.ShouldEqual(value);

        static int key;
        static string value;
        static IDictionary<int, string> dictionary;
        static TryOutable<string> @try;
    }
}
