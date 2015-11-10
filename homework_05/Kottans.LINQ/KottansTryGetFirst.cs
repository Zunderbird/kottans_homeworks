using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansTryGetFirst
    {
        public static bool TryGetFirst<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate,
    out TSource first)
        {
            if (source != null && predicate != null)
                foreach (var element in source)
                {
                    if (predicate(element))
                    {
                        first = element;
                        return true;
                    }
                }
            first = default(TSource);
            return false;
        }
    }
}
