using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 언제나휴일_도서검색csv_카카오api
{
    public class Book
    {
        public string Title
        {
            get;
            private set;
        }
        public string ISBN
        {
            get;
            private set;

        }
        public string Author
        {
            get;
            private set;
        }
        public Book(string title, string isbn, string author)
        {
            Title = title;
            ISBN = isbn;
            Author = author;
        }
    }
}
