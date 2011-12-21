namespace System
{
    public static class ObjectExtensions
    {
        public static T As<T>(this object @object)
        {
            return @object as T;
        }
    }
}
