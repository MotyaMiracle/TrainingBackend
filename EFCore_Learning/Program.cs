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

                Country usa = new Country { Name = "USA" };
                db.Countries.Add(usa);

                Company microsoft = new Company { Name = "Microsoft", Country = usa };
                Company google = new Company { Name = "Google", Country = usa };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Age = 33, Company = microsoft };
                User sam = new User { Name = "Sam", Age = 27, Company = google };
                User alice = new User { Name = "Alice", Age = 26, Company = microsoft };
                User kate = new User { Name = "Kate", Age = 30, Company = google };
                db.AddRange(tom, sam, alice, kate);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
            }
            using(ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.Join(db.Companies, // Второй выбор
                    u => u.CompanyId, // Свойство-селектор объекта из первого набора
                    c => c.Id, // Свойство-селектор объекта из второго набора
                    (u, c) => new // Результат
                    {
                        Name = u.Name,
                        Company = c.Name,
                        Age = u.Age
                    });
                foreach(var user in users)
                {
                    Console.WriteLine($"{user.Name} ({user.Company}) - {user.Age}");
                }
                Console.WriteLine();
            }
            // Аналогичный вариант JOIN
            using(ApplicationContext db = new ApplicationContext())
            {
                var users = from u in db.Users
                            join c in db.Companies on u.CompanyId equals c.Id
                            select new { Name = u.Name, Company = c.Name, Age = u.Age };
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name} ({user.Company}) - {user.Age}");
                }
                Console.WriteLine();
            }
            // Три таблицы в один набор
            using(ApplicationContext db = new ApplicationContext())
            {
                var users = from user in db.Users
                            join company in db.Companies on user.CompanyId equals company.Id
                            join country in db.Countries on company.CountryId equals country.Id
                            // Можно так
                            // select new { Name = user.Name, Company = user.Company!.Name, Country = user.Company!.Country!.Name };
                            select new { Name = user.Name, Company = company.Name, Country = country.Name };
                foreach (var u in users)
                    Console.WriteLine($"{u.Name} ({u.Company} - {u.Country})");
                Console.WriteLine();
            }
            // Группировка group by
            using(ApplicationContext db = new ApplicationContext())
            {
                var groups = from user in db.Users
                            group user by user.Company!.Name into g
                            select new
                            {
                                g.Key,
                                Count = g.Count(),
                            };
                foreach (var group in groups)
                {
                    Console.WriteLine($"{group.Key} - {group.Count}");
                }
                Console.WriteLine();
            }
            // Группировка GroupBy()
            using (ApplicationContext db = new ApplicationContext())
            {
                var groups = db.Users.GroupBy(u => u.Company!.Name).Select(g => new
                {
                    g.Key,
                    Count = g.Count()
                });
                foreach (var group in groups)
                {
                    Console.WriteLine($"{group.Key} - {group.Count}");
                }
                Console.WriteLine();
                var groupCountries = db.Companies.GroupBy(c => c.Country!.Name).Select(g => new
                {
                    g.Key,
                    Count = g.Count()
                });
                foreach (var group in groupCountries)
                {
                    Console.WriteLine($"{group.Key} - {group.Count}");
                }
            }
        }
    }
}