using System.Collections.Generic;
using Xunit;
using DataStructures.Lists;
using Xunit.Abstractions;
using DataStructures.Trees;
using System.Diagnostics;

namespace DataStructures.tests.TreeTests
{
    public class BinarySearchTreeTest
    {

        [Fact]
        public void StackTest()
        {
            IBinarySearchTree<int> BST = new BinarySearchTree<int>();

            //IBinarySearchTreeNode<int> node100 = new BinarySearchTreeNode<int>(100);
            //IBinarySearchTreeNode<int> node110 = new BinarySearchTreeNode<int>(110);
            //IBinarySearchTreeNode<int> node120 = new BinarySearchTreeNode<int>(120);
            //IBinarySearchTreeNode<int> node130 = new BinarySearchTreeNode<int>(130);
            //IBinarySearchTreeNode<int> node140 = new BinarySearchTreeNode<int>(140);
            //IBinarySearchTreeNode<int> node150 = new BinarySearchTreeNode<int>(150);
            //IBinarySearchTreeNode<int> node90 = new BinarySearchTreeNode<int>(90);
            //IBinarySearchTreeNode<int> node80 = new BinarySearchTreeNode<int>(80);
            //IBinarySearchTreeNode<int> node70 = new BinarySearchTreeNode<int>(70);
            //IBinarySearchTreeNode<int> node60 = new BinarySearchTreeNode<int>(60);
            //IBinarySearchTreeNode<int> node50 = new BinarySearchTreeNode<int>(50);

            var root = BST.AddNode(12);
            BST.AddNode(5);
            BST.AddNode(3);
            BST.AddNode(7);
            BST.AddNode(9);
            BST.AddNode(8);
            BST.AddNode(11);
            BST.AddNode(15);
            BST.AddNode(13);
            BST.AddNode(14);
            BST.AddNode(17);
            BST.AddNode(20);
            BST.AddNode(18);
                        
            string s = BST.DrawTree();
            Debug.WriteLine(s);
            var n = BST.RemoveNode(5);

            //BST.RemoveNode(170);
            //Debug.WriteLine(BST.DrawTree());
            //BST.RemoveNode(140);
            //Debug.WriteLine(BST.DrawTree());
            //BST.RemoveNode(60);
            //Debug.WriteLine(BST.DrawTree());
            



        }
    }
}
