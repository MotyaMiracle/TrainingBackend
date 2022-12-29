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
            // Метод Any() и All()
            using(ApplicationContext db = new ApplicationContext())
            {
                bool result = db.Users.Any(p => p.Company!.Name == "Google");
                Console.WriteLine(result);
                result = db.Users.All(p => p.Company!.Name == "Microsoft");
                Console.WriteLine(result);
            }
            // Метод Count()
            using(ApplicationContext db = new ApplicationContext())
            {
                int number1 = db.Users.Count();
                // Kол-во пользователей, которые в имени содержат подстроку Tom
                int number2 = db.Users.Count(p => p.Name == "Tom"); // можно так
                int number3 = db.Users.Count(u => u.Name!.Contains("Tom")); // а можно так
                Console.WriteLine(number1);
                Console.WriteLine(number2);
                Console.WriteLine(number3);
            }
            // Максимальное, минимальное и среднее значение
            using(ApplicationContext db = new ApplicationContext())
            {
                // минимальный возраст
                int minAge = db.Users.Min(p => p.Age);
                // максимальный возраст
                int maxAge = db.Users.Max(p => p.Age);
                // средний возраст пользователей, которые работают в Microsoft
                double avgAge = db.Users.Where(p => p.Company!.Name == "Microsoft")
                    .Average(p => p.Age);

                Console.WriteLine(minAge);
                Console.WriteLine(maxAge);
                Console.WriteLine(avgAge);
            }
            // Сумма значений
            using(ApplicationContext db = new ApplicationContext())
            {
                // суммарный возраст всех пользователей
                int sum1 = db.Users.Sum(p => p.Age);
                // суммарный возраст тех, кто работает в Microsoft
                int sum2 = db.Users.Where(u => u.Company!.Name == "Google")
                    .Sum(p => p.Age);
                Console.WriteLine(sum1);
                Console.WriteLine(sum2);
            }
        }
    }
}