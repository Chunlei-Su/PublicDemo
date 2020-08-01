using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager
{
    public class Book
    {
        public char bookId { get; set; }
        public string bookName{ get; set; }
        public int bookPrice { get; set; }
        public DateTime publisDate { get; set; }
        public string kogo { get; set; }
        public char catalogId { get; set; }

    }
}
