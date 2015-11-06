using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansDistinct
    {
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
        {
            return source.Distinct(null);
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            if (source == null) throw new ArgumentNullException();       
            if (comparer == null) comparer = EqualityComparer<TSource>.Default;
            return DistinctIterator(source, comparer);
        }

        public static IEnumerable<TSource> DistinctIterator<TSource>(IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            var distincts = new HashSet<TSource>(comparer);
            foreach (var element in source)
            {
                if (distincts.Add(element)) yield return element;
            }
        }
    }
}
