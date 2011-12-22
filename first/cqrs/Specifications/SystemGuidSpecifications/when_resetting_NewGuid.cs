namespace Dahlia.SystemGuidSpecifications
{
    using System;
    using Dahlia.Framework;
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
            firstValue.ShouldEqual(secondValue);
            secondValue.ShouldEqual(guid);
            thirdValue.ShouldNotEqual(guid);
        };

        static Guid guid;
        static Guid firstValue;
        static Guid secondValue;
        static Guid thirdValue;
    }
}
