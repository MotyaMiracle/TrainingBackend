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
                User kate = new User { Name = "Kate", Age = 25, Company = google };
                db.Users.AddRange(tom, sam, alice, kate);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

            }
            using (ApplicationContext db = new ApplicationContext()) 
            {
                // Можно использовать оператор new, если не создавть отдельный пользовательский тип
                var users = db.Users.Select(p => new UserModel
                {
                    Name = p.Name,
                    Age = p.Age,
                    Company = p.Company!.Name
                });
                foreach (UserModel user in users)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Company}");
                Console.WriteLine();
            }
            // Сортировка
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.OrderBy(p => p.Name).ToList();
                foreach (User user in users)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Id}");
                Console.WriteLine();
                var users1 = db.Users.OrderByDescending(p => p.Age).ToList();
                foreach (User user in users1)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Id}");
                Console.WriteLine();
                var users2 = db.Users.OrderBy(p => p.Name).ThenBy(p => p.Company!.Name).ToList();
                foreach (User user in users2)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Id}");
            }
        }
    }
}