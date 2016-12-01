using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public static class SelectionSorter
    {
        public static void SelectionSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;

            for (int i = 0; i < collection.Count; i++)
            {
                int imin = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (comparer.Compare(collection[imin], collection[j]) > 0)
                        imin = j;
                    
                }

                if (imin != i)
                {
                    collection.Swap(i, imin);
                }

            }
        }
    }
}
