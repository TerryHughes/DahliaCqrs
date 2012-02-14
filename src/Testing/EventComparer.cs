namespace Dahlia.Events
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class EventComparer : IEqualityComparer<Event>
    {
        public bool Equals(Event x, Event y)
        {
            if (x.AggregateRootId != y.AggregateRootId)
            {
                Debug.WriteLine(String.Format("The AggregateRootIds do not match: x = {0}, y = {1}", x.AggregateRootId, y.AggregateRootId));

                return false;
            }

            if (x.AggregateRootId == Guid.Empty)
            {
                Debug.WriteLine("The AggregateRootIds are empty");

                return false;
            }

            var typeOfX = x.GetType();
            var typeOfY = y.GetType();

            if (typeOfX != typeOfY)
            {
                Debug.WriteLine(String.Format("The types do not match: x = {0}, y = {1}", typeOfX, typeOfY));

                return false;
            }

            var valuesFromX = typeOfX.GetFields().Select(f => f.GetValue(x));
            var valuesFromY = typeOfY.GetFields().Select(f => f.GetValue(y));

            return valuesFromX.SequenceEqual(valuesFromY);
        }

        public int GetHashCode(Event obj)
        {
            unchecked
            {
                return obj.GetType().GetFields().Select(f => f.GetValue(obj)).Aggregate(17, (i, o) => i * (23 + o.GetHashCode()));
            }
        }
    }
}
