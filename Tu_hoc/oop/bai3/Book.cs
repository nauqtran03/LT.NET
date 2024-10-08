using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; private set; }
        
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false;

        } 
        public void Borrow()
        {
            if (IsBorrowed)
            {
                throw new InvalidOperationException("Sach chua co ai muon.");
            }
         
            IsBorrowed = true;
            
        }
        public void Return()
        {
            if (!IsBorrowed)
            {
                throw new InvalidOperationException("Sach khong duoc muon.");
            }
            IsBorrowed= false;
        }
    }
}
