namespace System.ObjectExtensions.Specs
{
    using Machine.Specifications;

    public class when_casting_String
    {
        Establish context =()=> value = originalValue = "string";

        Because of =()=> castedValue = value.As<string>();

        It should_match =()=> castedValue.ShouldEqual(originalValue);

        static string originalValue;
        static object value;
        static string castedValue;
    }
}
