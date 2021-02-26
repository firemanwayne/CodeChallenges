using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> RemoveDuplicates<T>(this T[] values)
        {
            if (values.Length == 0) return values;

            var valueList = values.ToList();            

            return valueList.Distinct();
        }
    }
}
