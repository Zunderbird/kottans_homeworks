using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansSingleOrDefault
    {
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source.SingleOrDefault(n => true);
        }

        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            TSource single;
            if (source.TryGetSingle(predicate, out single) <= 1) return single;
            throw new InvalidOperationException();
        }
    }
}
