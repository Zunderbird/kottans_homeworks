using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansWhere
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            return WhereIterator(source, predicate);
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            return WhereIterator(source, predicate);
        }

        private static IEnumerable<TSource> WhereIterator<TSource>(IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (predicate(element)) yield return element;
            }
        }

        private static IEnumerable<TSource> WhereIterator<TSource>(IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            var index = 0;

            foreach (var element in source)
            {
                if (predicate(element, index++)) yield return element;
            }
        }
    }
}
