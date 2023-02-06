using Module25.Models;
using System.Collections.Generic;

namespace Module25.Repositories
{
    public static class BookRepository
    {
        public static Book GetBook(int ID)
        {
            Book book;
            using (var db = new AppContext())
            {
                book = db.Books.Where(book => book.Id == ID).ToList().FirstOrDefault();
            }
            return book;
        }
        public static void AddBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(book);
            }
        }
        public static void EditBook(int ID, Book _book)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(book => book.Id == ID).ToList().FirstOrDefault();
                book = _book;
                db.SaveChanges();
            }
        }
        public static void EditBookName(int ID, string new_name)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(book => book.Id == ID).ToList().FirstOrDefault();
                book.Title = new_name;
                db.SaveChanges();
            }
        }
        public static void RemoveBook(int ID)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.Where(book => book.Id == ID).ToList().FirstOrDefault();
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
        public static void RemoveBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
        public static List<Book> GetAllBook()
        {
            List<Book> res;
            using (var db = new AppContext())
            {
                res = db.Books.ToList();
            }
            return res;
        }
        public static List<Book> GetBookByGenreAndYears(string genre, DateTime year1, DateTime year2)
        {
            List<Book> books;
            using (var db = new AppContext())
            {
                var booksQuery = from book in db.Books
                                 where book.Genre == genre && book.Year>= year1 && book.Year<= year2
                                 select book;

                books = booksQuery.ToList();
            }
            return books;
        }
        public static int GetQuantityOfBookByWriter(int writer_id)
        {
            int quantity=0;
            using (var db = new AppContext())
            {
                var quantityQuery = from book in db.Books
                                    where book.Writer.Id == writer_id
                                    select book;
                quantity = quantityQuery.Count();
            }
            return quantity;
        }
        public static int GetQuantityOfBookBygenre(string genre)
        {
            int quantity = 0;
            using (var db = new AppContext())
            {
                var quantityQuery = from book in db.Books
                                    where book.Genre == genre
                                    select book;
                quantity = quantityQuery.Count();
            }
            return quantity;
        }
        public static bool IsThereBookByTitleAndWriter(string title, int writer_id)
        {
            bool quantity;
            using (var db = new AppContext())
            {
                var quantityQuery = from book in db.Books
                                    where book.Writer.Id == writer_id && book.Title == title
                                    select book;
                quantity = quantityQuery.Count()>0;
            }
            return quantity;
        }
        public static Book GetLastBook()
        {
            Book book;
            using (var db = new AppContext())
            {
                book = db.Books.OrderByDescending(book => book.Year).ToList().FirstOrDefault();
            }
            return book;
        }
        public static List<Book> GetOrderedBooksByTitle()
        {
            List<Book> books;
            using (var db = new AppContext())
            {
                books = db.Books.OrderBy(book => book.Title).ToList();
            }
            return books;
        }
        public static List<Book> GetOrderedBooksByYear()
        {
            List<Book> books;
            using (var db = new AppContext())
            {
                books = db.Books.OrderByDescending(book => book.Year).ToList();
            }
            return books;
        }
    }
}
