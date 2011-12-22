namespace Dahlia.Framework.SystemGuidSpecs
{
    using System;
    using Machine.Specifications;

    public class when_stubbing_NewGuid : with_SystemGuid
    {
        Establish context =()=>
        {
            guid = Guid.NewGuid();
            SystemGuid.FromNowOnReturn(guid);
        };

        It should_return_the_same_Guids =()=>
        {
            firstValue.ShouldEqual(guid);
            secondValue.ShouldEqual(firstValue);
            thirdValue.ShouldEqual(secondValue);
        };

        Cleanup after =()=> SystemGuid.FromNowOnGenerateNew();

        static Guid guid;
    }
}
