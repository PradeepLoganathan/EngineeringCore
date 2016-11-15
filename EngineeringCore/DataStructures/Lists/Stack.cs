using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    /// <summary>
    /// Implements a FIFO stack datastructure.
    /// </summary>
    public class Stack<T> : IEnumerable<T> where T:IComparable<T>
    {
       
        private List<T> _collection;

        public Stack()
        {
            _collection = new List<T>();            
        }

        public Stack(int Capacity)
        {
            if (Capacity == 0)
                throw new ArgumentOutOfRangeException();

            _collection = new List<T>(Capacity);
        }

        

        public void Push(T GenericObject)
        {
            _collection.Insert(0, GenericObject);
        }


        public T Pop()
        {
            T value = _collection.First();
            _collection.RemoveAt(0);
            return value;
            
        }


        public int Count { get { return _collection.Count; } }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
    }
}
