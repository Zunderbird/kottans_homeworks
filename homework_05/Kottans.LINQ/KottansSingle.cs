using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansSingle
    {
        public static TSource Single<TSource>(this IEnumerable<TSource> source)
        {
            return source.Single(n => true);
        }

        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            TSource single;
            if (source.TryGetSingle(predicate, out single) == 1) return single;
            throw new InvalidOperationException();
        }
    }
}
