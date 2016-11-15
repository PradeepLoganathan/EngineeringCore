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
    }
}
