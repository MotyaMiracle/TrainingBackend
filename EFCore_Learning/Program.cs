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

                User tom = new User { Name = "Tom", Company = microsoft };
                User sam = new User { Name = "Sam", Company = microsoft };
                User alice = new User { Name = "Alice", Company = google };
                db.Users.AddRange(tom, sam, alice);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

            }
            // Получение данных
            using(ApplicationContext db = new ApplicationContext())
            {
                // Вывод пользователей
                var users = db.Users.Include(u => u.Company).ToList();
                foreach(User user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
                }

                // Вывод компаний
                var companies = db.Companies.Include(c => c.Users).ToList();
                foreach(Company company in companies)
                {
                    Console.WriteLine($"\n{company.Name}");
                    foreach(User user in company.Users)
                    {
                        Console.WriteLine($"{user.Name}");
                    }
                }
                Console.WriteLine();
                
            }
            // Редактирование данных
            using(ApplicationContext db = new ApplicationContext())
            {
                // изменение названия компании
                Company? company = db.Companies.FirstOrDefault(c => c.Name == "Google");
                if (company != null)
                {
                    company.Name = "Sony";
                    db.SaveChanges();
                }
                // изменение имени пользователя
                User? user1 = db.Users.FirstOrDefault(u => u.Name == "Tom");
                if(user1 != null)
                {
                    user1.Name = "Mike";
                    db.SaveChanges();
                }
                // смена компании сотрудника
                User? user2 = db.Users.FirstOrDefault(u => u.Name == "Sam");
                if (company != null && user2 != null)
                {
                    user2.Company = company;
                    db.SaveChanges();
                }
                var users = db.Users.Include(u => u.Company).ToList();
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
                }
                Console.WriteLine();
            }
            // Удаление данных
            using(ApplicationContext db = new ApplicationContext())
            {
                User? user1 = db.Users.FirstOrDefault(u => u.Name == "Sam");
                if (user1 != null)
                {
                    db.Users.Remove(user1);
                    db.SaveChanges();
                }

                Company? company = db.Companies.FirstOrDefault(c => c.Name == "Microsoft");
                if(company != null)
                {
                    db.Companies.Remove(company);
                    db.SaveChanges();
                }
                var users = db.Users.Include(u => u.Company).ToList();
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
                }
            }
        }
    }
}