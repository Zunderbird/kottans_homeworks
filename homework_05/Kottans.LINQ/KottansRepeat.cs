using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Repeat<TSource>(TSource source, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException();
            return RepeatIterator(source, count);
        }

        static IEnumerable<TSource> RepeatIterator<TSource>(TSource source, int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return source;
            }
        }
    }
}
