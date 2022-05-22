using System;
using System.Collections.Generic;
using System.Text;

namespace Implementing_Linked_List
{
    public class DoublyLinkedList
    {
        private LinkedList first = null;
        private LinkedList last = null;

        public int Count { get; protected set; }

        // adds an element at the beginning of the collection
        public void AddFirst(int element)
        {
            var newItem = new LinkedList(element);
            if (first == null) // Compare by reference
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                newItem.Next = first;
                first.Previous = newItem;
                first = newItem;
            }

            Count++;
        }

        // adds an element at the end of the collection
        public void AddLast(int element)
        {
            var newItem = new LinkedList(element);
            if (last == null) // Compare by reference
            {
                last = newItem;
                first = newItem;
            }
            else
            {
                last.Next = newItem;
                newItem.Previous = last;
                last = newItem;
            }

            Count++;
        }

        // removes the element at the beginning of the collection
        public int RemoveFirst()
        {
            int previousValue = first.Value;

            if (first == null) // 0 elements   // Compare by reference
            {
                // Exception
                throw new InvalidOperationException("Linked List is empty!!!");
            }
            else if (first == last) // 1 element  // Compare by reference
            {
                first = null;
                last = null;
            }
            else // more than 1 element
            {
                var newFirst = first.Next;
                newFirst.Previous = null;
                first = newFirst;
            }

            Count--;

            return previousValue;
        }

        // removes the element at the end of the collection
        public int RemoveLast()
        {
            int currLastElement = last.Value;
            if (last == null) // 0 elements   // Compare by reference
            {
                // Exception
                throw new InvalidOperationException("Linked List is empty!!!");
            }
            else if (first == last) // 1 element   // Compare by reference
            {
                last = null;
                first = null;
            }
            else // more than 1 element
            {
                var newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
            }

            Count--;

            return currLastElement;
        }


        // goes through the collection and executes a given action
        public void ForEach(Action<int> action)
        {
            var currElement = first;
            while (currElement != null)
            {
                action(currElement.Value);
                currElement = currElement.Next;
            }
        }

        // returns the collection as an array
        public int[] ToArray()
        {
            //int[] array = new int[Count];

            //int index = 0;
            //var currElement = first;
            //while (currElement != null)
            //{
            //    array[index++] = currElement.Value;
            //    currElement = currElement.Next;
            //}

            // return array;

            var list = new List<int>();

            LinkedList currElement = first;
            while (currElement != null)
            {
                list.Add(currElement.Value);
                currElement = currElement.Next;
            }

            return list.ToArray();
        }
    }
}
