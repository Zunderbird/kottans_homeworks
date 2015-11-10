using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansTryGetSingle
    {
        public static int TryGetSingle<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, out TSource single)
        {
            single = default(TSource);
            var count = 0;

            if (source != null && predicate != null)
            {
                foreach (var element in source)
                {
                    if (predicate(element))
                    {
                        count++;
                        if (count == 1) single = element;
                        if (count > 1) break;
                    }
                }
            }
            single = (count == 1) ? single : default(TSource);
            return count;
        }
    }
}
