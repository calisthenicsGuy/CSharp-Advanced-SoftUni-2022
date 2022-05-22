using System;
using System.Collections.Generic;
using System.Text;

namespace Implementing_Linked_List
{
    public class LinkedList
    {
        private LinkedList previous;
        private LinkedList next;
        private int value;


        public LinkedList(int value)
        {
            this.Value = value;
        }


        public LinkedList Previous
        { get => previous; set => this.previous = value; }
        public LinkedList Next
        { get => next; set => this.next = value; }
        public int Value
        { get => value; set => this.value = value; }
    }
}
