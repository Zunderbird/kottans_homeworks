using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansFirst
    {
        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            return source.First(n => true);
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();
            TSource first;
            if (source.TryGetFirst(predicate, out first)) return first;
            throw new InvalidOperationException();
        }
    }
}
