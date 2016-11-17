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

        void InsertAfter(ISinglyLinkedNode<T> Node, T Data);

        void InsertBefore(ISinglyLinkedNode<T> Node, T Data);

        ISinglyLinkedNode<T> GetAt(int Index);

        void RemoveAt(int Index);

        void RemoveAfter(ISinglyLinkedNode<T> Node);

        void RemoveBefore(ISinglyLinkedNode<T> Node);

        void Remove(ISinglyLinkedNode<T> Node);

        void ReverseList();

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
    public class SinglyLinkedNode<T> : IDisposable, IComparable<SinglyLinkedNode<T>>, ISinglyLinkedNode<T> where T:IComparable<T>
    {
        private T _data;
        private ISinglyLinkedNode<T> _next;

        #region constructors
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

        #endregion

        public T Data { get { return _data; } set { _data = value; } }
        public ISinglyLinkedNode<T> Next { get { return _next; } set { _next = value; } }

       

        int IComparable<SinglyLinkedNode<T>>.CompareTo(SinglyLinkedNode<T> other)
        {
            if (other == null)
                return -1;

            return this.Data.CompareTo(other.Data);

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    IDisposable disposable = _data as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();

                }

                disposedValue = true;
            }
        }

       
        public void Dispose()
        {  
            Dispose(true);
        }
        #endregion


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

            ISinglyLinkedNode<T> Temp = _head;

            for (int i = 0; i < Index - 1; i++)
            {
                Temp = Temp.Next;
            }

            return Temp;
        }

        void ISinglyLinkedList<T>.Remove(ISinglyLinkedNode<T> Node)
        {
            //empty linked list
            if (_head == null)
                return;

            for (ISinglyLinkedNode<T> current = _head, prev = null; current!= null; prev = current, current = current.Next)
            {
                if (current.Data.CompareTo(Node.Data) == 0)
                {
                    prev.Next = current.Next;
                    break;
                }
                    
            }

        }

        void ISinglyLinkedList<T>.RemoveAfter(ISinglyLinkedNode<T> Node)
        {
            Node.Next = Node.Next.Next;
        }

        void ISinglyLinkedList<T>.RemoveAt(int Index)
        {   
            (this as ISinglyLinkedList<T>).Remove((this as ISinglyLinkedList<T>).GetAt(Index));
        }

        void ISinglyLinkedList<T>.RemoveBefore(ISinglyLinkedNode<T> Node)
        {
            //cannot remove before head
            if (object.Equals(Node.Data, _head.Data))
                return;

            //if we need to remove the node before tail then make head and tail the same
            if (Node.Data.CompareTo(_tail.Data) == 0)
            {
                _head = _tail;
                (_tail as IDisposable).Dispose();
            }

            for (ISinglyLinkedNode<T> currentnode = _head, child = null, grandchild = null; currentnode != null;  currentnode = currentnode.Next)
            {
                child = currentnode.Next;
                grandchild = child.Next;

                if (Node.Data.CompareTo(grandchild.Data) == 0)
                {
                    currentnode.Next = grandchild;
                    break;
                }
                
            }
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
            ISinglyLinkedNode<T> currentnode = _head;

            //check if there is only one node. Remove head then
            if (_head.Next == null)
            {
                _head = null;
                return;
            }

            //if there are only two nodes set heads next to null to remove tail
            if (_head.Next != null && _head.Next.Next == null)
            {
                _head.Next = null;
                return;
            }

            for (ISinglyLinkedNode<T> current = _head, child = current.Next, grandchild = child.Next; current != null ; current = current.Next)
            {


            }





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

        void ISinglyLinkedList<T>.InsertAfter(ISinglyLinkedNode<T> Node, T Data)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.InsertBefore(ISinglyLinkedNode<T> Node, T Data)
        {
            throw new NotImplementedException();
        }

        void ISinglyLinkedList<T>.ReverseList()
        {
            //               < __ < __ < __ __: reversedPart: head
            //                 (__)__ __ __
            //head :   current:      >  >  >
            ISinglyLinkedNode <T> reversedPart = null;
            ISinglyLinkedNode<T> current = _head;

            while (current != null)
            {
                ISinglyLinkedNode<T> next = current.Next;
                current.Next = reversedPart;
                reversedPart = current;
                current = next;
            }

            _head = reversedPart;
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
