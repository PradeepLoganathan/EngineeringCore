using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Algorithms;
using Algorithms.Sorting;

namespace Algorithms.tests
{
    public class BubbleSorterTest
    {
        [Fact]
        public void BubbleSortTest()
        {
            List<int> list1 = new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            List<int> list2 = new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            list1.BubbleSort();
            list2.Sort();

            Assert.Equal(list1, list2);
            
        }

        
    }

}
