using System;
using System.Collections;
using System.Collections.Generic;
using EngineeringCore.Algorithms;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //List<int> numbers = new List<int> {1, 2, 3, 6, 7, 9};
            List<int> numbers = new List<int> {9, 7, 6, 3, 2, 1};
            
            numbers.BubblesortAscending(Comparer<int>.Default);
            Console.WriteLine("Hello World!");
        }
    }
}
