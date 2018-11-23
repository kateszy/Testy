using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Stos;

namespace Testy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanCreateInstanceOfStack()
        {
            new Stos.Stack<int>();

        }

        [TestMethod]
        public void CanPushNotNullElementToStack()
        {
            Stos.Stack<int> stack = new Stos.Stack<int>();
            stack.Push(1);
        }

        public void PushNullElementRaiseArgumentNullException()
        {
            Stos.Stack<int?> stack = new Stos.Stack<int?>();
            Assert.ThrowsException<ArgumentNullException>(() => stack.Push(null));
        }

        [TestMethod]
        public void CanPopElementFromNotEmptyList()
        {
            Stos.Stack<int> stack = new Stos.Stack<int>();
            stack.Push(1);
            Assert.AreEqual(stack.Pop(), 1);
        }

        [TestMethod]
        public void PopReturnsSameObjectAsHasBeenPush()
        {
            List<int> element = new List<int>();
            Stos.Stack<List<int>> stack = new Stos.Stack<List<int>>();
            stack.Push(element);
            Assert.AreSame(stack.Pop(), element);
        }

        [TestMethod]
        public void PopEmptyStackaRaiseInvalidOperationException()
        {
            Stos.Stack<int> stack = new Stos.Stack<int>();
            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void StackPopAndPushWorksLikeLIFO()
        {
            Stos.Stack<int> stack = new Stos.Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(stack.Pop(), 3);
            Assert.AreEqual(stack.Pop(), 2);

            stack.Push(4);
            stack.Push(5);
            Assert.AreEqual(stack.Pop(), 5);
            Assert.AreEqual(stack.Pop(), 4);
            Assert.AreEqual(stack.Pop(), 1);
        }

        [TestMethod]
        public void PeekDosentRemoveObjectFromStackMemory()
        {
            Stos.Stack<int> stack = new Stos.Stack<int>();
            stack.Push(1);
            Assert.AreEqual(stack.Peek(), 1);
            Assert.AreEqual(stack.Peek(), 1);
        }

        [TestMethod]
        public void PeekEmptyStackaRaiseInvalidOperationException()
        {
            Stos.Stack<int> stack = new Stos.Stack<int>();
            Assert.ThrowsException<InvalidOperationException>(() => stack.Peek());
        }

    }
}
