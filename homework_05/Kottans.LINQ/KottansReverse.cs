using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansReverse
    {
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            return ReverceIterator(source);
        }

        private static IEnumerable<TSource> ReverceIterator<TSource>(IEnumerable<TSource> source)
        {
            var tempList = source.ToList();
            for (var i = tempList.Count - 1; i >= 0; i--)
            {
                yield return tempList[i];
            }
        }
    }
}
