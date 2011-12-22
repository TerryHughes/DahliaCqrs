namespace Dahlia.Framework.SystemGuidSpecs
{
    using Machine.Specifications;

    public class when_using_NewGuid : with_SystemGuid
    {
        It should_return_different_Guids =()=>
        {
            firstValue.ShouldNotEqual(thirdValue);
            secondValue.ShouldNotEqual(firstValue);
            thirdValue.ShouldNotEqual(secondValue);
        };
    }
}
