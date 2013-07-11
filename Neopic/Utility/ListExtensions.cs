using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Linq
{
    public static class ListExtensions
    {
        public static IEnumerable<T> RadialSlice<T>(this IList<T> list, int index, int radius)
        {
            Check.ArgumentIsNotNull(list, "list");
            Check.ArgumentIsLessThan(index, list.Count, "index");
            Check.ArgumentIsLessThanOrEqual(radius, list.Count / 2, "radius");

            int min = index - radius;
            if (min < 0)
                min += list.Count;

            int count = Math.Min(list.Count, (2 * radius) + 1);
            for (int i = 0; i < count; i++)
            {
                yield return list[min++];
                if (min >= list.Count)
                    min = 0;
            }
        }
    }
}
