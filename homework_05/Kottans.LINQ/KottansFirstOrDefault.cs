using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansFirstOrDefault
    {
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source.FirstOrDefault(n => true);
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            TSource first;
            source.TryGetFirst(predicate, out first);
            return first;
        }
    }
}
