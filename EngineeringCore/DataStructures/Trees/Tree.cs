using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public interface BinarySearchTreeNode<T>  
    {
        BinarySearchTreeNode<T> Parent { get; set; }
        BinarySearchTreeNode<T> LeftChild { get; set; }
        BinarySearchTreeNode<T> RightChild { get; set; }
        bool HasChildren();
        bool HasLeftChild();
        bool HasRightChild();
        bool IsLeftChild();
        bool IsRightChild();
        bool IsLeaf();
        int ChildrenCount { get; }
        T Data { get; set; }
    }

    public interface ITree<T>
    {
        BinarySearchTreeNode<T> Root { get; }
        BinarySearchTreeNode<T> AddChild(T Node);
    }
}
