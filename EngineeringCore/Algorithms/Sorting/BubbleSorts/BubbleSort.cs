using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public static class BubbleSorter
    {
        public static void BubbleSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
                
            for (int i = 0; i < collection.Count; i++)
            {
                for(int j = 0; j < collection.Count - 1; j++)
                {
                    if (comparer.Compare(collection[j], collection[j + 1]) > 0)
                    {
                        T temp = collection[j + 1];
                        collection[j + 1] = collection[j];
                        collection[j] = temp;
                    }
                }
            }
        }


        

    }
}
