using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Box_of_T
{
    internal class Box<T>
    {

        public Box()
        {
            this.Elements = new Stack<T>();
        }

        public Stack<T> Elements { get; set; }

        public void Add(T element)
        {
            this.Elements.Push(element);
        }
        public T Remove()
        {
            return this.Elements.Pop();
        }
        public int Count()
        {
            return this.Elements.Count;
        }
    }
}
