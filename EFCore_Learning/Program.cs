using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;

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
                
                Company microsoft = new Company { Name = "Microsoft"};
                Company google = new Company { Name = "Google"};
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Age = 33, Company = microsoft };
                User sam = new User { Name = "Sam", Age = 27, Company = google };
                User alice = new User { Name = "Alice", Age = 26, Company = microsoft };
                User kate = new User { Name = "Kate", Age = 30, Company = google };
                db.AddRange(tom, sam, alice, kate);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
            }
            // Объединение
            using (ApplicationContext db = new ApplicationContext())
            {

                var users = db.Users.Where(u => u.Age < 30)
                    .Union(db.Users.Where(u => u.Name!.Contains("Tom")));
                foreach(var user in users)
                {
                    Console.WriteLine(user.Name);
                }
                // не можем объединить две разнородные выборки, например, таблицу, пользователей и таблицу компаний.
                // Однако уместна запись
                var result = db.Users.Select(p => new { Name = p.Name })
                    .Union(db.Companies.Select(c => new { Name = c.Name }));
                Console.WriteLine();
            }
            // Пересечение
            using(ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Where(p => p.Age > 30)
                    .Intersect(db.Users.Where(p => p.Name == "Tom"));
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
                Console.WriteLine();
            }
            // Разность
            using(ApplicationContext db = new ApplicationContext())
            {
                var selector1 = db.Users.Where(p => p.Age >= 30);
                var selector2 = db.Users.Where(p => p.Name == "Tom");
                var users = selector1.Except(selector2);
                foreach(var user in users)
                {
                    Console.WriteLine(user.Name);
                }
                Console.WriteLine();
                var selector3 = db.Users.Where(p => p.Company!.Name == "Microsoft");
                var selector4 = db.Users.Where(p => p.Name == "Tom");
                var users1 = selector3.Except(selector4);
                foreach (var user in users1)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }
    }
}