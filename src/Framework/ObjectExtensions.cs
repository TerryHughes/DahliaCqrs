namespace System.ObjectExtensions
{
    public static class Class
    {
        public static T As<T>(this object @object)
        {
            return (T)@object;
        }
    }
}
