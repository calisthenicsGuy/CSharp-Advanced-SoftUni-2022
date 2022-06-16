using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P01.Library
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public List<Book> Books{ get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.Books.Count; i++)
            {
                yield return this.Books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //public IEnumerator<Book> GetEnumerator()
        //{
        //    return new LibraryIterator(this.Books.ToArray());
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}


        //private class LibraryIterator : IEnumerator<Book>
        //{

        //    public LibraryIterator(params Book[] books)
        //    {
        //        this.Index = -1;
        //        this.Books = new List<Book>(books);
        //    }

        //    public List<Book> Books { get; }
        //    public int Index { get; private set; }

        //    public Book Current => this.Books[Index];

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose()
        //    {
        //    }

        //    public bool MoveNext()
        //    {
        //        this.Index++;
        //        return this.Index < this.Books.Count;
        //    }

        //    public void Reset()
        //    {
        //        this.Index = -1;
        //    }
        //}
    }
}
