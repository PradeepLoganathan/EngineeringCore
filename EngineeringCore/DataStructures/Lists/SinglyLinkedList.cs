using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Lists
{

    public interface ISinglyLinkedNode<T> where T : IComparable<T>
    {
        T Data { get; set; }
        ISinglyLinkedNode<T> Next { get; set; }
    }

    public interface ISinglyLinkedList<T> where T:IComparable<T>
    {
        ISinglyLinkedNode<T> Head { get; }

        ISinglyLinkedNode<T> Tail { get; }

        void Add(ISinglyLinkedNode<T> Data);

        void AddHead(ISinglyLinkedNode<T> Data);

        void AddTail(ISinglyLinkedNode<T> Data);

        void RemoveHead();

        void RemoveTail();

        void AddAt(int Index, ISinglyLinkedNode<T> Data);

        ISinglyLinkedNode<T> GetAt(int Index);

        void RemoveAt(int Index);

        void RemoveAfter(ISinglyLinkedNode<T> Node);

        void RemoveBefore(ISinglyLinkedNode<T> Node);

        void Remove(ISinglyLinkedNode<T> Node);

    }

    public interface IPrintLinkedList
    {
        void PrintLinkedList();
    }


    /// <summary>
    /// Definition of a Singly linked node. This node has a data slot and a single pointer slot pointing to the next
    /// singly linked node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedNode<T> : IComparable<SinglyLinkedNode<T>>, ISinglyLinkedNode<T> where T:IComparable<T>
    {
        private T _data;
        private ISinglyLinkedNode<T> _next;

        public SinglyLinkedNode()
        {
            _data = default(T);
            _next = null;
        }

        public SinglyLinkedNode(T data)
        {
            _data = data;
            _next = null;
        }

        public T Data { get { return _data; } set { _data = value; } }
        public ISinglyLinkedNode<T> Next { get { return _next; } set { _next = value; } }

       

        int IComparable<SinglyLinkedNode<T>>.CompareTo(SinglyLinkedNode<T> other)
        {
            if (other == null)
                return -1;

            return this.Data.CompareTo(other.Data);

        }

        
    }

    /// <summary>
    /// Implements ISinglyLinkedList and defines a singly linked linked list
    /// </summary>
    /// <typeparam name="T">Template type</typeparam>
    public class SinglyLinkedList<T> : ISinglyLinkedList<T>, IPrintLinkedList,IEnumerable<T> where T : IComparable<T>
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

           
        }

        ISinglyLinkedNode<T> ISinglyLinkedList<T>.Tail
        {
            get
            {
                return _tail;
            }
           
        }

        void ISinglyLinkedList<T>.Add(ISinglyLinkedNode<T> Data)
        {
            (this as ISinglyLinkedList<T>).AddHead(Data);
        }

        void ISinglyLinkedList<T>.AddAt(int Index, ISinglyLinkedNode<T> Data)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.AddHead(ISinglyLinkedNode<T> Data)
        {
            Data.Next = _head;
            _head = Data;
        }

        void ISinglyLinkedList<T>.AddTail(ISinglyLinkedNode<T> Data)
        {
            _tail.Next = Data;
            _tail = Data;
        }

        ISinglyLinkedNode<T> ISinglyLinkedList<T>.GetAt(int Index)
        {
            if (Index < 0)
                return new SinglyLinkedNode<T>();

            ISinglyLinkedNode<T> Temp = null;

            for (int i = 0; i == Index + 1; i++)
            {
                Temp = _head.Next;
            }

            return Temp;
        }

        void ISinglyLinkedList<T>.Remove(ISinglyLinkedNode<T> Node)
        {
            //empty linked list
            if (_head == null)
                return;

            for (ISinglyLinkedNode<T> temp = _head, prev = null; temp.Next != null; prev = temp, temp = temp.Next)
            {
                if (object.Equals(temp.Data, Node.Data))
                    prev.Next = temp.Next;
                    
            }

        }

        void ISinglyLinkedList<T>.RemoveAfter(ISinglyLinkedNode<T> Node)
        {
            Node.Next = Node.Next.Next;
        }

        void ISinglyLinkedList<T>.RemoveAt(int Index)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.RemoveBefore(ISinglyLinkedNode<T> Node)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.RemoveHead()
        {
            lock (_head)
            {
                lock (_head.Next)
                {
                    _head = _head.Next;
                }
            }
        }

        void ISinglyLinkedList<T>.RemoveTail()
        {

        }
        #endregion


        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>();
        }


        #endregion

        void IPrintLinkedList.PrintLinkedList()
        {
            PrintNode(_head);
        }
        void PrintNode(ISinglyLinkedNode<T> Node)
        {
            if (Node == null)
            {
                Debug.Write(" | " + "NULL"+ " | " + "\n");
                return;
            }

            Debug.Write(" | " + Node.Data + " | " + "-->");

            PrintNode(Node.Next);
        }

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
