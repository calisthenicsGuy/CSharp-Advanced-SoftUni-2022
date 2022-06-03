using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Generic_Scale
{
    internal class EqualityScale<T>
    {
        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;

        }

        public T Left { get; set; }
        public T Right { get; set; }

        public bool AreEqual()
        {
            if (this.Left.ToString() == this.Right.ToString())
            {
                return true;
            }

            return false;
        }
    }
}
