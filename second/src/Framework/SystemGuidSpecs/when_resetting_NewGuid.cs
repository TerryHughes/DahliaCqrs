namespace Dahlia.Framework.SystemGuidSpecs
{
    using System;
    using Machine.Specifications;

    public class when_resetting_NewGuid
    {
        Establish context =()=>
        {
            guid = Guid.NewGuid();
            SystemGuid.FromNowOnReturn(guid);
        };

        Because of =()=>
        {
            firstValue = SystemGuid.NewGuid();
            secondValue = SystemGuid.NewGuid();

            SystemGuid.FromNowOnGenerateNew();

            thirdValue = SystemGuid.NewGuid();
        };

        It should_return_different_Guids =()=>
        {
            firstValue.ShouldEqual(guid);
            secondValue.ShouldEqual(firstValue);

            thirdValue.ShouldNotEqual(guid);
        };

        static Guid guid;
        static Guid firstValue;
        static Guid secondValue;
        static Guid thirdValue;
    }
}
