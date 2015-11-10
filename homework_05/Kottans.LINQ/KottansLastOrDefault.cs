using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansLastOrDefault
    {
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source.LastOrDefault(n => true);
        }

        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var result = source.Reverse();
            return result.FirstOrDefault(predicate);
        }

        public static TSource LastOrDefault<TSource>(this IList<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            return (source.Count > 0) ? source[source.Count - 1] : default(TSource);
        }
    }
}
