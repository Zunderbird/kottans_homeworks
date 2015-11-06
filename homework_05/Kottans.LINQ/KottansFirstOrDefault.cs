﻿using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class KottansFirstOrDefault
    {
        public static TSourse FirstOrDefault<TSourse>(this IEnumerable<TSourse> source)
        {
            return source.FirstOrDefault(n => true);
        }

        public static TSourse FirstOrDefault<TSourse>(this IEnumerable<TSourse> source, Func<TSourse, bool> predicate)
        {
            if (source == null || predicate == null) throw new ArgumentNullException();

            foreach (var element in source)
            {
                if (predicate(element)) return element;
            }
            return default(TSourse);
        }
    }
}
