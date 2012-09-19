using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Data;

namespace F1.Live.Core.Extensions
{
    public static class LinqExtensions
    {
         public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action) where T : Entity
         {
             foreach (var item in enumerable.OrderBy(x => x.Id))
             {
                 action(item);
             }
         }
    }
}