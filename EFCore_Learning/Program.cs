namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Company microsoft = new Company { CompanyName = "Microsoft" };
                Company google = new Company { CompanyName = "Google" };
                db.Companies.AddRange(microsoft, google);
                db.SaveChanges();

                User tom = new User { Name = "Tom", Age = 33, Company = microsoft };
                User alice = new User { Name = "Alice", Age = 26, Company = google };
                User sam = new User { Name = "Sam", Age = 28, Company = microsoft };
                User kate = new User { Name = "Kate", Age = 24, Company = google };
                db.Users.AddRange(tom, alice, sam, kate);
                db.SaveChanges();

                Console.WriteLine("Данные успешно добавлены");

                // получаем данные из бд
                foreach (var user in db.Users.ToList())
                {
                    Console.WriteLine(user.Name);
                }

                // Удаляем первую компанию
                var comp = db.Companies.FirstOrDefault();
                if (comp != null) db.Companies.Remove(comp);
                db.SaveChanges();
                Console.WriteLine("\nСписок пользователей после удаления компании");
                // снова получаем пользователей
                foreach (var user in db.Users.ToList()) Console.WriteLine(user.Name);
            }
        }
    }
}