using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static partial class Enumerable
    {
        public static IEnumerable<int> Range(int start, int count)
        {
            var max = (long)start + count - 1;
            if (count < 0 || max > int.MaxValue) throw new ArgumentOutOfRangeException();
            return RangeIterator(start, count);
        }

        static IEnumerable<int> RangeIterator(int start, int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }
    }
}
