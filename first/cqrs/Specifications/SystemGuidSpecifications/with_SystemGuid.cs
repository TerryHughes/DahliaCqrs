namespace Dahlia.SystemGuidSpecifications
{
    using System;
    using Dahlia.Framework;
    using Machine.Specifications;

    public abstract class with_SystemGuid
    {
        Because of =()=>
        {
            _firstValue = SystemGuid.NewGuid();
            _secondValue = SystemGuid.NewGuid();
            _thirdValue = SystemGuid.NewGuid();
        };

        protected static Guid _firstValue;
        protected static Guid _secondValue;
        protected static Guid _thirdValue;
    }
}
