using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansConcat
    {
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, 
            IEnumerable<TSource> second)
        {
            if (first == null || second == null) throw new ArgumentNullException();
            return ConcatIterator(first, second);
        }

        private static IEnumerable<TSource> ConcatIterator<TSource>(IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            foreach (var element in first)
            {
                yield return element;
            }
            foreach (var element in second)
            {
                yield return element;
            }
        }
    }
}
