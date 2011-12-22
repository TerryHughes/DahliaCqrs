namespace Dahlia.SystemGuidSpecifications
{
    using System;
    using Dahlia.Framework;
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
            _firstValue.ShouldEqual(_secondValue);
            _secondValue.ShouldEqual(_thirdValue);
            _thirdValue.ShouldEqual(guid);
        };

        Cleanup mess =()=> SystemGuid.FromNowOnGenerateNew();

        static Guid guid;
    }
}
