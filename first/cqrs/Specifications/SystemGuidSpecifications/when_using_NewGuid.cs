namespace Dahlia.SystemGuidSpecifications
{
    using Machine.Specifications;

    public class when_using_NewGuid : with_SystemGuid
    {
        It should_return_different_Guids =()=>
        {
            _firstValue.ShouldNotEqual(_secondValue);
            _secondValue.ShouldNotEqual(_thirdValue);
            _thirdValue.ShouldNotEqual(_firstValue);
        };
    }
}
