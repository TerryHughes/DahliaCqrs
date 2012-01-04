namespace Dahlia.DictionaryExtensionSpecifications
{
    using System.Collections.Generic;
    using Dahlia.Framework;
    using Machine.Specifications;

    public class when_trying_to_get_a_value_that_does_not_exist
    {
        Establish context =()=>
        {
            key = 1;
            value = "one";
            dictionary = new Dictionary<int, string> { { key, value } };
        };

        Because of =()=> @try = dictionary.TryGetValue(key + 1);

        It should_have_failed =()=> @try.Failed.ShouldBeTrue();

        It should_not_have_a_value =()=> @try.Value.ShouldBeNull();

        static int key;
        static string value;
        static IDictionary<int, string> dictionary;
        static TryOutable<string> @try;
    }
}
