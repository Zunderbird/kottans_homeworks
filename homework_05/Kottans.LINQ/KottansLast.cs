using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansLast
    {
        public static TSource Last<TSource>(this IEnumerable<TSource> source)
        {
            return source.Last(n => true);
        }

        public static TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var result = source.Reverse();
            return result.First(predicate);
        }

        public static TSource Last<TSource>(this IList<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            if (source.Count <= 0) throw new InvalidOperationException();
            return source[source.Count - 1];            
        }
    }
}
