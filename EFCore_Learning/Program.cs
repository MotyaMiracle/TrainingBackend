using Microsoft.EntityFrameworkCore;

namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                // создаем два объекта
                User tom = new User { Name = "Tom", Age = 33 };
                User sam = new User { Name = "Sam", Age = 27 };
                User alice = new User { Name = "Alice", Age = 26 };
                User kate = new User { Name = "Kate", Age = 30 };

                // добавляем объекты в бд
                db.Users.AddRange(tom, sam, alice, kate);
                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
            }
            using(ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.FirstOrDefault();
                if(user != null)
                {
                    user.Age = 18;
                    db.SaveChanges();
                }
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Name} ({u.Age})");
                }
                Console.WriteLine();
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault();
                if (user != null)
                {
                    user.Age = 22;
                    db.SaveChanges();
                }
                var users = db.Users.AsNoTracking().ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Name} ({u.Age})");
                }
                Console.WriteLine();
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                var user = db.Users.AsNoTracking().FirstOrDefault();
                if (user != null)
                {
                    user.Age = 8;
                    db.SaveChanges();
                }
                var users = db.Users.AsNoTracking().ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Name} ({u.Age})");
                }
                Console.WriteLine();
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Name} ({u.Age})");
                }
                int count = db.ChangeTracker.Entries().Count();
                Console.WriteLine(count);
            }
        }
    }
}