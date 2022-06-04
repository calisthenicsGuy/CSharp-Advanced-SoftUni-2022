using System;

namespace Stack
{
    internal class CustomStack<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private const string EMPTY_STACK_EXC_MSG = "Stack is empty!";

        private T[] items;

        public CustomStack()
        {
            this.items = new T[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.items = Resize();
            }
            
            this.items[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK_EXC_MSG);
            }

            T poppedItem = this.items[this.Count - 1];

            this.items[this.Count - 1] = default;
            this.Count--;

            return poppedItem;
        }

        public T Peek()
        {
            return this.items[this.Count - 1];
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        public T[] Resize()
        {
            var newResizeArray = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                newResizeArray[i] = this.items[i];
            }

            return newResizeArray;
        }
    }
}
