using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    public class Reader
    {
        public string Name { get; set; }
        public string ReaderID {  get; set; }
        public Reader(string name, string readerid)
        {
            Name = name;
            ReaderID = readerid;
        }
        public void BorrowBook(Book book) => book.Borrow();
        public void RrturnBook(Book book) => book.Return();
    }
    
}
    