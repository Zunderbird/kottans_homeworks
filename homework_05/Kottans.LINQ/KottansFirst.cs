using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansFirst
    {
        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            return source.First(n => n != null);
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();
            foreach (var element in source)
            {
                if (predicate(element)) return element;
            }
            throw new InvalidOperationException();
        }
    }
}
