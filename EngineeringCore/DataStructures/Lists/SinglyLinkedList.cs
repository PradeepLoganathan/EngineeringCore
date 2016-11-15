using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Lists
{

    public interface ISinglyLinkedNode<T> where T : IComparable<T>
    {
        T Data { get; set; }
        SinglyLinkedNode<T> Next { get; set; }
    }

    interface ISinglyLinkedList<T> where T:IComparable<T>
    {
        ISinglyLinkedNode<T> Head { get; set; }

        ISinglyLinkedNode<T> Tail { get; set; }

        void Add(ISinglyLinkedNode<T> Data);

        void AddHead(ISinglyLinkedNode<T> Data);

        void AddTail(ISinglyLinkedNode<T> Data);

        void AddAt(int Index, ISinglyLinkedNode<T> Data);
        
        T GetAt(int Index);

        void RemoveAt(int Index);

        void RemoveAfter(ISinglyLinkedNode<T> Node);

        void RemoveBefore(ISinglyLinkedNode<T> Node);

        void Remove(ISinglyLinkedNode<T> Node);

    }
    /// <summary>
    /// Definition of a Singly linked node. This node has a data slot and a single pointer slot pointing to the next
    /// singly linked node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedNode<T> : IComparable<SinglyLinkedNode<T>>, ISinglyLinkedNode<T> where T:IComparable<T>
    {
        private T _data;
        private SinglyLinkedNode<T> _next;

        public SinglyLinkedNode()
        {
            _data = default(T);
            _next = null;
        }

        public T Data { get { return _data; } set { _data = value; } }
        public SinglyLinkedNode<T> Next { get { return _next; } set { _next = value; } }

       

        int IComparable<SinglyLinkedNode<T>>.CompareTo(SinglyLinkedNode<T> other)
        {
            if (other == null)
                return -1;

            return this.Data.CompareTo(other.Data);

        }

        
    }
    public class SinglyLinkedList<T> : ISinglyLinkedList<T>, IEnumerable<T> where T : IComparable<T>
    {
        private ISinglyLinkedNode<T> _head;
        private ISinglyLinkedNode<T> _tail;

        public SinglyLinkedList()
        {
            _head = null;
            _tail = null;
        }

        #region ISinglyLinkedList imlplementation
        ISinglyLinkedNode<T> ISinglyLinkedList<T>.Head
        {
            get
            {
                return _head;
            }

            set
            {
                _head = value;
            }
        }

        ISinglyLinkedNode<T> ISinglyLinkedList<T>.Tail
        {
            get
            {
                return _tail;
            }

            set
            {
                _tail = value;
            }
        }

        void ISinglyLinkedList<T>.Add(ISinglyLinkedNode<T> Data)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.AddAt(int Index, ISinglyLinkedNode<T> Data)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.AddHead(ISinglyLinkedNode<T> Data)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.AddTail(ISinglyLinkedNode<T> Data)
        {
            throw new NotImplementedException();
        }

        T ISinglyLinkedList<T>.GetAt(int Index)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.Remove(ISinglyLinkedNode<T> Node)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.RemoveAfter(ISinglyLinkedNode<T> Node)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.RemoveAt(int Index)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.RemoveBefore(ISinglyLinkedNode<T> Node)
        {
            throw new NotImplementedException();
        }
        #endregion

        internal class SinglyLinkedListEnumerator<T> : IEnumerator<T>
        {
            public T Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
