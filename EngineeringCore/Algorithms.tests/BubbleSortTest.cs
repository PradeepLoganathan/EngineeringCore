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
            List<int> list1 = Enumerable.Range(1, 100).Reverse().ToList();
            List<int> list2 = Enumerable.Range(1, 100).ToList();
            list1.BubbleSort();

            Assert.Equal(list1, list2);
            
        }

        
    }

}

