using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public interface IBinarySearchTreeNode<T> : IComparable<IBinarySearchTreeNode<T>> where T : IComparable<T>
    {
        IBinarySearchTreeNode<T> Parent { get; set; }
        IBinarySearchTreeNode<T> LeftChild { get; set; }
        IBinarySearchTreeNode<T> RightChild { get; set; }
        bool HasChildren { get; }
        bool HasLeftChild { get; }
        bool HasRightChild { get; }
        bool IsLeftChild { get; }
        bool IsRightChild { get; }
        bool IsLeaf { get; }
        int ChildrenCount { get; }
        T Data { get; set; }
    }
    public interface IBinarySearchTree<T> where T : IComparable<T>
    {
        IBinarySearchTreeNode<T> Root { get; }
        int Count { get; }
        IBinarySearchTreeNode<T> AddNode(T Value);
        IBinarySearchTreeNode<T> FindNode(T Value);
        IBinarySearchTreeNode<T> RemoveNode(T Value);
    }
    public interface IPrintBinarySearchTree
    {
        String PrintTree();
    }
    public class BinarySearchTreeNode<T> : IPrintBinarySearchTree, IBinarySearchTreeNode<T> where T : IComparable<T>
    {
        private IBinarySearchTreeNode<T> _left;
        private IBinarySearchTreeNode<T> _right;
        private IBinarySearchTreeNode<T> _parent;
        private T _data;
        public BinarySearchTreeNode(T Value)
        {
            _left = _right = _parent = null;
            _data = Value;
        }
        int IBinarySearchTreeNode<T>.ChildrenCount
        {
            get
            {
                int count = 0;
                if ((this as IBinarySearchTreeNode<T>).HasLeftChild)
                    count++;
                if ((this as IBinarySearchTreeNode<T>).HasRightChild)
                    count++;
                return count;
            }
        }
        T IBinarySearchTreeNode<T>.Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
        IBinarySearchTreeNode<T> IBinarySearchTreeNode<T>.LeftChild
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }
        IBinarySearchTreeNode<T> IBinarySearchTreeNode<T>.Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        IBinarySearchTreeNode<T> IBinarySearchTreeNode<T>.RightChild
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
            }
        }

        bool IBinarySearchTreeNode<T>.HasChildren
        {
            get
            {
                return ((this as IBinarySearchTreeNode<T>).ChildrenCount > 0);
            }
        }

        bool IBinarySearchTreeNode<T>.HasLeftChild
        {
            get { return _left != null; }
        }

        bool IBinarySearchTreeNode<T>.HasRightChild
        {
            get { return _right != null; }
        }

        bool IBinarySearchTreeNode<T>.IsLeaf
        {
            get { return (_left == null && _right == null); }
        }

        bool IBinarySearchTreeNode<T>.IsLeftChild
        {
            get
            {
                if ((_parent as IBinarySearchTreeNode<T>).LeftChild == this)
                    return true;
                else
                    return false;
            }
        }

        bool IBinarySearchTreeNode<T>.IsRightChild
        {
            get
            {
                if ((_parent as IBinarySearchTreeNode<T>).RightChild == this)
                    return true;
                else
                    return false;
            }
        }

        public int CompareTo(IBinarySearchTreeNode<T> other)
        {
            return this._data.CompareTo((T)other);
        }

        string IPrintBinarySearchTree.PrintTree()
        {
            return (this as IBinarySearchTree<T>).DrawTree<T>();
        }
    }

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private IBinarySearchTreeNode<T> _root;

        public BinarySearchTree()
        {
            _root = null;
        }

        int IBinarySearchTree<T>.Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        IBinarySearchTreeNode<T> IBinarySearchTree<T>.Root
        {
            get
            {
                return _root;
            }
        }
        IBinarySearchTreeNode<T> IBinarySearchTree<T>.AddNode(T Value)
        {
            IBinarySearchTreeNode<T> node = new BinarySearchTreeNode<T>(Value);
            IBinarySearchTreeNode<T> parent = null;
            IBinarySearchTreeNode<T> current = null;

            if (_root == null)
            {
                _root = node;
                return node;
            }

            current = _root;

            while (current != null)
            {
                parent = current;
                if (current.Data.CompareTo(node.Data) < 0)
                    current = current.RightChild;
                else
                    current = current.LeftChild;
            }

            if (parent.Data.CompareTo(node.Data) <= 0)
            {
                parent.RightChild = node;
                node.Parent = parent;
            }
            else
            {
                parent.LeftChild = node;
                node.Parent = parent;
            }

            return node;
        }
        IBinarySearchTreeNode<T> IBinarySearchTree<T>.FindNode(T Value)
        {
            //Root itself is null
            if (_root == null)
                return null;

            IBinarySearchTreeNode<T> current = _root;

            while (current != null)
            {
                if (current.Data.CompareTo(Value) == 0)
                    break;
                else if (current.Data.CompareTo(Value) > 0)
                    current = current.LeftChild;
                else
                    current = current.RightChild;
            }

            return current;
        }

        IBinarySearchTreeNode<T> IBinarySearchTree<T>.RemoveNode(T Value)
        {
            return this.Remove(_root, Value);
        }

        private IBinarySearchTreeNode<T> Remove(IBinarySearchTreeNode<T> Root, T value)
        {
            IBinarySearchTreeNode<T> CurrentNode = (this as IBinarySearchTree<T>).FindNode(value);

            if (CurrentNode == null)
                return null;

            IBinarySearchTreeNode<T> Parent = CurrentNode.Parent;

            if (CurrentNode.ChildrenCount == 2) // Has both left and right children
            {
                IBinarySearchTreeNode<T> temp = this.FindMinNode(CurrentNode.RightChild); //find minimum in right subtree
                CurrentNode.Data = temp.Data;//copy the value in the minimum to current
                CurrentNode.RightChild = temp.RightChild;//delete the node with single child
            }
            else if (CurrentNode.HasLeftChild)//Only has left child
            {
                CurrentNode.Parent.LeftChild = CurrentNode.LeftChild;
                CurrentNode.LeftChild.Parent = CurrentNode.Parent;
            }
            else if (CurrentNode.HasRightChild) //Only has right child
            {
                CurrentNode.Parent.RightChild = CurrentNode.RightChild;
                CurrentNode.RightChild.Parent = CurrentNode.Parent;
            }
            else //No children
            {
                if (CurrentNode.Parent.LeftChild == CurrentNode)
                    CurrentNode.Parent.LeftChild = null;
                else if (CurrentNode.Parent.RightChild == CurrentNode)
                    CurrentNode.Parent.RightChild = null;
            }

            return CurrentNode;
        }

        /// <summary>
        /// Find the minium value below this node
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        public IBinarySearchTreeNode<T> FindMinNode(IBinarySearchTreeNode<T> Node)
        {
            if (Node == null)
                return null;

            IBinarySearchTreeNode<T> current = Node;

            while (current.HasLeftChild)
                current = current.LeftChild;

            return current;

        }
        /// <summary>
        /// Find the maximum value below this node
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        public IBinarySearchTreeNode<T> FindMaxNode(IBinarySearchTreeNode<T> Node)
        {
            if (Node == null)
                return null;

            IBinarySearchTreeNode<T> current = Node;

            while (current.HasRightChild)
                current = current.RightChild;

            return current;

        }
    }
}

