using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansAny
    {
        public static bool Any<TSource>(this IEnumerable<TSource> source)
        {
            return source.Any(n => n != null);
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();
            foreach (var element in source)
            {
                if (predicate(element)) return true;
            }
            return false;
        }
    }
}
