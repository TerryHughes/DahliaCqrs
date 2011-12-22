namespace System.ObjectExtensions.Specs
{
    using System;
    using Machine.Specifications;

    public class when_casting_Guid
    {
        Establish context =()=> value = originalValue = new Guid("01234567-89AB-CDEF-0123-456789ABCDEF");

        Because of =()=> castedValue = value.As<Guid>();

        It should_match =()=> castedValue.ShouldEqual(originalValue);

        static Guid originalValue;
        static object value;
        static Guid castedValue;
    }
}
