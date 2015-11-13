using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansGroupBy
    {
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            if (source == null || 
                keySelector == null)
                throw new ArgumentNullException();

            return GroupByIterator(source, keySelector, n => n);
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
        {
            if (source == null || 
                keySelector == null || 
                resultSelector == null)
                throw new ArgumentNullException();

            var groups = SplitByGroups(source, keySelector, n => n);
            return GroupByIterator(groups, resultSelector);
        }

        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
           this IEnumerable<TSource> source,
           Func<TSource, TKey> keySelector,
           Func<TSource, TElement> elementSelector)
        {
            if (source == null || 
                keySelector == null || 
                elementSelector == null)
                throw new ArgumentNullException();

            return GroupByIterator(source, keySelector, elementSelector);
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            if (source == null || 
                keySelector == null || 
                elementSelector == null || 
                resultSelector == null) throw new 
                    ArgumentNullException();

            var groups = SplitByGroups(source, keySelector, elementSelector);
            return GroupByIterator(groups, resultSelector);
        }

        private static IEnumerable<IGrouping<TKey, TElement>> GroupByIterator<TSource, TKey, TElement>(
            IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            var groups = SplitByGroups(source, keySelector, elementSelector);
            foreach (var group in groups)
            {
                yield return group;
            }           
        }

        private static IEnumerable<TResult> GroupByIterator<TKey, TElement, TResult>(
            IEnumerable<IGrouping<TKey, TElement>> groups,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            foreach (var element in groups)
            {
                yield return resultSelector(element.Key, element);
            }
        }

        private static IEnumerable<IGrouping<TKey, TElement>> SplitByGroups<TSource, TKey, TElement>(
            IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            var keys = new HashSet<TKey>();
            var groups = new List<Grouping<TKey, TElement>>();

            foreach (var element in source)
            {
                var key = keySelector(element);

                if (!keys.Contains(key))
                {
                    var group = new Grouping<TKey, TElement>(key);
                    keys.Add(key);
                    foreach (var elem in source)
                    {
                        if (keySelector(elem) == null && key == null ||
                        keySelector(elem) != null && keySelector(elem).Equals(key))
                            group.Add(elementSelector(elem));
                    }
                    groups.Add(group);
                }
            }
            return groups;
        }
    }

}
