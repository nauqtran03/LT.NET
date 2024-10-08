namespace bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book("1984", "George Orwell", "123456789");
            Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "987654321");

            library.AddBook(book1);
            library.AddBook(book2);

            Reader reader1 = new Reader("Tran Quang Quan", "DV001");
            library.AddReader(reader1);

            library.BorrowBook(reader1, book1);
            Console.WriteLine($"Book: {book1.Title}, borrowed: {book1.IsBorrowed}");

            library.ReturnBook(reader1, book1);
            Console.WriteLine($"Book: {book1.Title}, borrowed: {book1.IsBorrowed}");
        }
    }
}
