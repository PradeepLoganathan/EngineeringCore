using System;
using System.Collections.Generic;


namespace EngineeringCore.Algorithms
{
    //Create extenstion methods for List types.duck typing and fluent 
    //the first parameter this extends the  IList implementations 
    public static class Bubblesort
    {
        
        public static void BubblesortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            bool leftelementsmaller = false;
            do
            {
                for (int i =0; i <= collection.Count; i++)
                {
                    if( comparer.Compare(collection[i], collection[i+1]) > 0 )
                    {
                        var temp = collection[i];
                        collection[i] = collection[i + 1];
                        collection[i + 1] = temp;
                        leftelementsmaller = true;
                    }
                }

            }while( leftelementsmaller == true )  ;
        }

        public static void BubblesortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
                 
        } 
    }
    
}