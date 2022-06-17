using System;
using System.Diagnostics;
using System.Threading;
using System.Numerics;
using System.Collections.Generic;

namespace Implementing_Linked_List
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var item = new ImplementedLinkedList(15);
            //item.Previous = new ImplementedLinkedList(14);
            //item.Next = new ImplementedLinkedList(16);

            //Console.WriteLine(item.Previous.Value);
            //Console.WriteLine(item.Value);
            //Console.WriteLine(item.Next.Value);

            //item.Previous.Previous = new ImplementedLinkedList(13);
            //Console.WriteLine(item.Previous.Previous.Value);

            //item.Next.Next = new ImplementedLinkedList(17);
            //Console.WriteLine(item.Next.Next.Value);

            //List<ImplementedLinkedList> linkedList = new List<ImplementedLinkedList>();
            //linkedList.Add(item);


            //var list = new DoublyLinkedList();
            //list.AddFirst(3);
            //list.AddFirst(2);
            //list.AddLast(1);
            //list.AddLast(4);

            //list.AddFirst(0);
            //list.AddLast(100);

            //list.RemoveFirst();
            //list.RemoveLast();

            //list.AddLast(5);
            //Console.WriteLine(list.Count);

            //Console.WriteLine(string.Join(", ", list.ToArray()));

            //list.ForEach(i => Console.Write($"{i} "));

            
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();
            linkedList.AddHead(1);
            linkedList.AddHead(2);
            linkedList.AddTail(3);
            Console.WriteLine(linkedList.Head.Value);
            Console.WriteLine(linkedList.Tail.Previous.Value);
            Console.WriteLine(linkedList.Tail.Value);
            // 2, 1, 3
            Console.WriteLine();
            Console.WriteLine(linkedList.RemoveHead());
            Console.WriteLine(linkedList.Head.Value);
            // 1, 3
            Console.WriteLine();
            linkedList.AddTail(5);
            // 1, 3, 5
            Console.WriteLine(linkedList.RemoveTail());
            Console.WriteLine(linkedList.Tail.Value);
            // 1, 3
            linkedList.ForEach(x => Console.WriteLine(x));
            var array = linkedList.ToArray();
        }
    }
}
