namespace System
{
    using System.Reflection;

    public static class ObjectExtensions
    {
        public static T GetNonPublicInstanceField<T>(this object @object, string fieldName)
        {
            return @object.GetNonPublicInstanceFieldFromBaseClass<T>(@object.GetType(), fieldName);
        }

        public static T GetNonPublicInstanceFieldFromBaseClass<T>(this object @object, Type type, string fieldName)
        {
            var fieldInfo = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            return (T)fieldInfo.GetValue(@object);
        }

        public static void SetNonPublicInstanceField(this object @object, string fieldName, object value)
        {
            var fieldInfo = @object.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            fieldInfo.SetValue(@object, value);
        }

        public static void InvokeNonPublicInstanceMethod(this object @object, string methodName, object[] parameters)
        {
            @object.InvokeNonPublicInstanceMethod<object>(methodName, parameters);
        }

        public static T InvokeNonPublicInstanceMethod<T>(this object @object, string methodName, object[] parameters)
        {
            var methodInfo = @object.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            return (T)methodInfo.Invoke(@object, parameters) ;
        }
    }
}
