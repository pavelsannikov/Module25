using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Module25.Models;
using Module25.Repositories;
class Program
{
    public static void Main()
    {
        /*
        using (var db = new Module25.AppContext())
        {
            var user1 = new User { Name = "Гоша",Email = "gosha@mail.ru" };
            var user2 = new User { Name = "Кристина",Email = "kristina@gmail.com" };
            var writer1 = new Writer { Name = "Пушкин"};
            var book1 = new Book { Title = "Евгений Онегин", Year = new DateTime(1831, 10, 5), Writer = writer1,Genre = "Роман"};
        

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Writers.Add(writer1);
            db.Books.Add(book1);
            db.SaveChanges();
            


        }*/
        Console.WriteLine(BookRepository.GetQuantityOfBookByWriter(1));
        Console.WriteLine(BookRepository.GetQuantityOfBookBygenre("Роман"));
    }
    public void GiveBookToUser(int user_ID, int book_id)
    {
        using (var db = new Module25.AppContext())
        {
            var user = db.Users.Where(user => user.Id == user_ID).ToList().FirstOrDefault();
            var book = db.Books.Where(book => book.Id == book_id).ToList().FirstOrDefault();
            user.Books.Add(book);
            db.SaveChanges();
        }
    }
}