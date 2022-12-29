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

                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Age = 33, Company = microsoft };
                User sam = new User { Name = "Sam", Age = 27, Company = google };
                User alice = new User { Name = "Alice", Age = 26, Company = microsoft };
                User kate = new User { Name = "Kate", Age = 30, Company = google };
                db.AddRange(tom, sam, alice, kate);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

            }
            // Использование Where
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Where(p => p.Company!.Name == "Google");
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Age}");
                }
                Console.WriteLine();
            }
            // Аналогичный запос с помощью операторов LINQ
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = (from user in db.Users
                             where user.Company!.Name == "Google"
                             select user).ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Age}");
                }
                Console.WriteLine();
            }
            // Оператор LIKE
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Where(p => EF.Functions.Like(p.Name!, "%Tom%"));
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Age}");
                }
                Console.WriteLine();
            }
            // Приведение в оцениваемого выражение свойство
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Where(p => EF.Functions.Like(p.Age.ToString(), "2%"));
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Age}");
                }
                Console.WriteLine();
            }
            // Метод Find
            using (ApplicationContext db = new ApplicationContext())
            {
                User? user = db.Users.Find(3);
                if (user != null)
                    Console.WriteLine($"{user.Name} ({user.Age})");
                User? user1 = db.Users.FirstOrDefault();
                if (user1 != null)
                    Console.WriteLine($"{user1.Name} ({user1.Age})");
            }
        }
    }
}