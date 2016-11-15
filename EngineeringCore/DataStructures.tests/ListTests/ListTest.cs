using System.Collections.Generic;
using Xunit;
using DataStructures.Lists;

namespace DataStructures.tests.ListTests
{
    public class ListTest
    {
        [Fact]
        public void StackTest()
        {
            Lists.Stack<string> MyStack = new Lists.Stack<string>();
            MyStack.Push("First");
            MyStack.Push("Second");
            MyStack.Push("Third");
            var i = MyStack.Pop();
            var j = MyStack.Pop();
            var k = MyStack.Pop();

        }

        [Fact]
        public void SinglyLinkedListTest()
        {
            ISinglyLinkedList<int> singlylinkedlist = new SinglyLinkedList<int>();
            ISinglyLinkedNode<int> nodeone = new SinglyLinkedNode<int>(1);
            ISinglyLinkedNode<int> nodetwo = new SinglyLinkedNode<int>(2);
            ISinglyLinkedNode<int> nodethree = new SinglyLinkedNode<int>(3);
            ISinglyLinkedNode<int> nodefour = new SinglyLinkedNode<int>(4);


            singlylinkedlist.AddHead(nodeone);
            singlylinkedlist.AddHead(nodetwo);
            singlylinkedlist.AddHead(nodethree);
            singlylinkedlist.AddHead(nodefour);

        }
    }
}
