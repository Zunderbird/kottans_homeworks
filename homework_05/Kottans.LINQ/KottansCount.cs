using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansCount
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            return source.Count(n => true);
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            var count = 0;

            checked { foreach (var element in source) if (predicate(element)) count++; }

            return count;
        }
    }
}
