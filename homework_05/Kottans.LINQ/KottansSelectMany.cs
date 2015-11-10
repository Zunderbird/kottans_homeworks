using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansSelectMany
    {
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, 
            Func<TSource, IEnumerable<TResult>> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();
            return SelectManyIterator(source, predicate);
        }

        private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(IEnumerable<TSource> source, 
            Func<TSource, IEnumerable<TResult>> predicate)
        {
            foreach (var element in source)
            {
                foreach (var tempElement in predicate(element))
                {
                    yield return tempElement;
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, 
            Func<TSource, int, IEnumerable<TResult>> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();
            return SelectManyIterator(source, predicate);
        }

        private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(IEnumerable<TSource> source, 
            Func<TSource, int, IEnumerable<TResult>> predicate)
        {
            int counter = 0;
            foreach (var element in source)
            {
                foreach (var tempElement in predicate(element, counter++))
                {
                    yield return tempElement;
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, 
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null || collectionSelector == null || resultSelector == null) throw new ArgumentNullException();
            return SelectManyIterator(source, collectionSelector, resultSelector);
        }

        private static IEnumerable<TResult> SelectManyIterator<TSource, TCollection, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            foreach (var element in source)
            {
                foreach (var tempElement in collectionSelector(element))
                {
                    yield return resultSelector(element, tempElement);
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source,
           Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
           Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null || collectionSelector == null || resultSelector == null) throw new ArgumentNullException();
            return SelectManyIterator(source, collectionSelector, resultSelector);
        }

        private static IEnumerable<TResult> SelectManyIterator<TSource, TCollection, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            var count = 0;
            foreach (var element in source)
            {
                foreach (var tempElement in collectionSelector(element, count++))
                {
                    yield return resultSelector(element, tempElement);
                }
            }
        }
    }
}
