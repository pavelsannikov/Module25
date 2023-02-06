using Module25.Models;

namespace Module25.Repositories
{
    public static class UserRepository
    {
        public static User GetUser(int ID)
        {
            User user;
            using (var db = new AppContext())
            {
                user = db.Users.Where(user => user.Id == ID).ToList().FirstOrDefault();
            }
            return user;
        }
        public static void AddUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(user);
            }
        }
        public static void EditUser(int ID, User _user)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.Where(user => user.Id == ID).ToList().FirstOrDefault();
                user = _user;
                db.SaveChanges();
            }
        }
        public static void EditUserName(int ID, string new_name)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.Where(user => user.Id == ID).ToList().FirstOrDefault();
                user.Name = new_name;
                db.SaveChanges();
            }
        }
        public static void RemoveUser(int ID)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.Where(user => user.Id == ID).ToList().FirstOrDefault();
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public static void RemoveUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public static List<User> GetAllUser()
        {
            List<User> res;
            using (var db = new AppContext())
            {
                res = db.Users.ToList();
            }
            return res;
        }
        public static bool DoUserHaveBook(int user_id, int book_id)
        {
            bool quantity;

            using (var db = new AppContext())
            {
                var user = db.Users.Where(user => user.Id == user_id).ToList().FirstOrDefault();

                var quantityQuery = from book in user.Books
                                    where book.Id == book_id
                                    select book;
                quantity = quantityQuery.Count() > 0;
            }
            return quantity;
        }
        public static int GetQuantityOfBookByUser(int user_id)
        {
            int quantity = 0;
            using (var db = new AppContext())
            {
                var user = db.Users.Where(user => user.Id == user_id).ToList().FirstOrDefault();

                var quantityQuery = from book in user.Books select book;
                quantity = quantityQuery.Count();
            }
            return quantity;
        }
    }
}
