namespace System.Collections.Generic
{
    using System.Threading;

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> SlowlyEnumerate<T>(this IEnumerable<T> items, int millisecondsTimeout)
        {
            foreach (var item in items)
            {
                Thread.Sleep(millisecondsTimeout);

                yield return item;
            }
        }
    }
}
