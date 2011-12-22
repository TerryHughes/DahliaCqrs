namespace Dahlia.Framework.SystemGuidSpecs
{
    using System;
    using Machine.Specifications;

    public abstract class with_SystemGuid
    {
        Because of =()=>
        {
            firstValue = SystemGuid.NewGuid();
            secondValue = SystemGuid.NewGuid();
            thirdValue = SystemGuid.NewGuid();
        };

        protected static Guid firstValue;
        protected static Guid secondValue;
        protected static Guid thirdValue;
    }
}
