using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansToList
    {
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException();
            return ToListIterator(source);
        }

        private static List<TSource> ToListIterator<TSource>(IEnumerable<TSource> source)
        {
            var result = new List<TSource>();
            foreach (var element in source)
            {
                result.Add(element);
            }
            return result;
        }
    }
}
