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
                User alice = new User { Name = "Alice", Company = google };
                User sam = new User { Name = "Sam", Company = microsoft };
                User kate = new User { Name = "Kate", Company = google };
                db.Users.AddRange(tom, alice, sam, kate);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                foreach(User user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
                }
                Console.WriteLine("------");
            }
            using(ApplicationContext db = new ApplicationContext())
            {
                var companies = db.Companies.ToList();
                foreach(Company company in companies)
                {
                    Console.WriteLine($"{company.Name}");
                    foreach(User user in company.Users)
                    {
                        Console.WriteLine($"{user.Name}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}