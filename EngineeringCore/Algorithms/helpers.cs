using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class helpers
    {
        public static void Swap<T>(this IList<T> list, int firstindex, int secondindex)
        {
            if (list.Count < 2 || firstindex == secondindex)
                return;

            T temp = list[firstindex];
            list[firstindex] = list[secondindex];
            list[secondindex] = temp;
        }
    }
}
