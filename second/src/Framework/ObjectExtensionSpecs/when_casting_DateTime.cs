namespace System.ObjectExtensions.Specs
{
    using System;
    using Machine.Specifications;

    public class when_casting_DateTime
    {
        Establish context =()=> value = originalValue = new DateTime(2011, 06, 06);

        Because of =()=> castedValue = value.As<DateTime>();

        It should_match =()=> castedValue.ShouldEqual(originalValue);

        static DateTime originalValue;
        static object value;
        static DateTime castedValue;
    }
}
