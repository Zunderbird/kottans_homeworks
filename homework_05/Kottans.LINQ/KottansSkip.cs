using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansSkip
    {
        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null) throw new ArgumentNullException();
            return SkipIterator(source, count);
        }

        public static IEnumerable<TSource> SkipIterator<TSource>(IEnumerable<TSource> source, int count)
        {
            var counter = 0;
            foreach (var element in source)
            {
                if (count <= counter++) yield return element;
            }
        }
    }
}
