namespace Dahlia.Framework
{
    using System;

    public static class SystemGuid
    {
        static Guid? staticGuid;

        public static Guid NewGuid()
        {
            return staticGuid ?? Guid.NewGuid();
        }

        public static void FromNowOnReturn(Guid guid)
        {
            staticGuid = guid;
        }

        public static void FromNowOnGenerateNew()
        {
            staticGuid = null;
        }
    }
}
