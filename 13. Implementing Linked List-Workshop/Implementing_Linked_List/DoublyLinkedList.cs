using System;
using System.Collections.Generic;
using System.Text;

namespace Implementing_Linked_List
{
    public class DoublyLinkedList<T>
    {
        public int Count { get; private set; }
        public bool IsEmpty => this.Count == 0;

        public LinkedListNode Head { get; private set; }
        public LinkedListNode Tail { get; private set; }


        public void AddHead(T element)
        {
            if (IsEmpty)
            {
                this.Head = this.Tail = new LinkedListNode(element);
            }
            else if (!IsEmpty)
            {
                var newHead = new LinkedListNode(element);
                var previousHead = this.Head;          
                this.Head = newHead;
                previousHead.Previous = this.Head;
                this.Head.Next = previousHead;
            }

            this.Count++;
        }

        public void AddTail(T element)
        {
            if (IsEmpty)
            {
                this.Tail = this.Head = new LinkedListNode(element);
            }
            else if (!IsEmpty)
            {
                var previousTail = this.Tail;
                var newTail = new LinkedListNode(element);
                this.Tail = newTail;
                this.Tail.Previous = previousTail;
                previousTail.Next = this.Tail;
            }

            this.Count++;
        }

        public T RemoveHead()
        {
            if (IsEmpty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidOperationException("Linked List is empty! Cannot remove element from empty linked list!");
            }

            var removedHead = this.Head;
            var newHead = removedHead.Next;

            if (newHead == null)
            {
                this.Head = null;
                this.Tail = null;
            }
            else if (newHead != null)
            {
                newHead.Previous = null;
                removedHead.Next = null;
                this.Head = newHead;
            }

            this.Count--;
            return removedHead.Value;
        }

        public T RemoveTail()
        {
            if (IsEmpty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidOperationException("Linked List is empty! Cannot remove element from empty linked list!");
            }

            var removedTail = this.Tail;
            var newTail = removedTail.Previous;

            if (newTail == null)
            {
                this.Head = this.Tail = null;
            }
            else if (newTail != null)
            {
                removedTail.Previous = null;
                newTail.Next = null;
                this.Tail= newTail;
            }

            this.Count--;
            return removedTail.Value;
        }

        public void ForEach(Action<T> action)
        {
            var currNode = this.Head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.Next;
            }
        }

        public List<T> ToList()
        {
            var list = new List<T>();
            this.ForEach(x => list.Add(x));
            return list;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            int counter = 0;
            this.ForEach(x => array[counter++] = x);
            return array;
        }

        public class LinkedListNode
        {
            public LinkedListNode(T value)
            {
                this.Value = value;
            }

            public LinkedListNode Previous { get; set; }
            public T Value { get; set; }
            public LinkedListNode Next { get; set; }
        }
    }
}
