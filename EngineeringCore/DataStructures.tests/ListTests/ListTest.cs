using System.Collections.Generic;
using Xunit;
using DataStructures.Lists;
using Xunit.Abstractions;

namespace DataStructures.tests.ListTests
{
    public class ListTest
    {
        private readonly ITestOutputHelper output;

        public ListTest(ITestOutputHelper output)
        {
            this.output = output;
        }

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


            IPrintLinkedList printlist;
            printlist = singlylinkedlist as IPrintLinkedList;

            ISinglyLinkedNode<int> nodeone = new SinglyLinkedNode<int>(1);
            ISinglyLinkedNode<int> nodetwo = new SinglyLinkedNode<int>(2);
            ISinglyLinkedNode<int> nodethree = new SinglyLinkedNode<int>(3);
            ISinglyLinkedNode<int> nodefour = new SinglyLinkedNode<int>(4);

            
            printlist.PrintLinkedList();

            singlylinkedlist.AddHead(nodeone);
            singlylinkedlist.AddHead(nodetwo);
            singlylinkedlist.AddHead(nodethree);
            singlylinkedlist.AddHead(nodefour);

            printlist.PrintLinkedList();

            ISinglyLinkedNode<int> temp = singlylinkedlist.GetAt(2);

            singlylinkedlist.RemoveAt(2);

            //singlylinkedlist.RemoveAfter(temp);
            //singlylinkedlist.Remove(temp);

            printlist.PrintLinkedList();

            //singlylinkedlist.RemoveHead();

            //printlist.PrintLinkedList();

            //singlylinkedlist.RemoveBefore(nodetwo);

            singlylinkedlist.ReverseList();

            printlist.PrintLinkedList();

            

        }
    }
}
