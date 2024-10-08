using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    internal class Library
    {
        private List<Book> Books = new List<Book>();
        private List<Reader> Readers = new List<Reader>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void AddReader(Reader reader) 
        {
            Readers.Add(reader);
        }
        public void BorrowBook(Reader reader, Book book)
        {
            if (!Books.Contains(book))
            {
                throw new ArgumentException("Sach khong co trong thu vien.");
            }
            reader.BorrowBook(book);
        }
        public void ReturnBook(Reader reader, Book book)
        {
            if (!Books.Contains(book)) 
            {
                throw new ArgumentException("Sach khong co trong thu vien");
            }
            reader.RrturnBook(book);
        }
    }
}
