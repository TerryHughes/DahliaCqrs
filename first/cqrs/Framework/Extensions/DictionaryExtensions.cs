namespace System.Collections.Generic
{
    using Dahlia.Framework;

    public static class DictionaryExtensions
    {
        public static TryOutable<TValue> TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;

            var result = dictionary.TryGetValue(key, out value);

            return new TryOutable<TValue>(result, value);
        }
    }
}
