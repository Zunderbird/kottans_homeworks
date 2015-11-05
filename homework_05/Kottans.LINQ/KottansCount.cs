using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansCount
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();

            var count = 0;

            foreach (var element in source)
            {
                if (count == int.MaxValue) throw new OverflowException();
                count++;
            }

            return count;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            var count = 0;

            foreach (var element in source)
            {
                if (count == int.MaxValue) throw new OverflowException();
                if (predicate(element)) count++;
            }

            return count;
        }
    }
}
