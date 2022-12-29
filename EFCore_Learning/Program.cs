using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

                Company microsoft = new Company { Name= "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Age = 33, Company= microsoft };
                User sam = new User { Name = "Sam", Age = 27, Company= google };
                User alice = new User { Name = "Alice", Age = 26, Company = microsoft };
                User kate = new User { Name = "Kate", Age = 25, Company = google };
                db.Users.AddRange(tom, sam, alice, kate);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

            }
            // Использование некоторых операторов LINQ
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = (from user in db.Users.Include(p => p.Company)
                             where user.CompanyId == 1
                             select user).ToList();
                foreach(var user in users)
                {
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Company?.Name}");
                }
                Console.WriteLine();
            }
            // Использование методов расширения LINQ
            using( ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Include(p => p.Company).Where(p => p.CompanyId == 1);
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Company?.Name}");
                }
                Console.WriteLine();
                var companies = db.Companies.Include(c => c.Users).Where(c => c.Name == "Tom");
                foreach (var company in companies)
                {
                    Console.WriteLine($"{company.Name}");
                }
            }
        }
    }
}