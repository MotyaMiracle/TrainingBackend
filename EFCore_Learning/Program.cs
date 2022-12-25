namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Установка главной сущности по навигационному свойству зависимой сущности
                //Company microsoft = new Company { Name = "Microsoft" };
                //Company google = new Company { Name = "Google" };

                //Установка главной сущности по свойству-внешнему ключу зависимой сущности
                //Company microsoft = new Company { Name = "Microsoft" };
                //Company google = new Company { Name = "Google" };

                //db.Companies.AddRange(microsoft, google);
                //db.SaveChanges();

                //User tom = new User { Name = "Tom", CompanyId = microsoft.Id };
                //User alice = new User { Name = "Alice", CompanyId = google.Id };
                //User sam = new User { Name = "Sam", CompanyId = google.Id };

                //db.Users.AddRange(tom, alice, sam);
                //db.SaveChanges();

                //Установка зависимой сущности через навигационное свойство главной сущности
                User user1 = new User { Name = "Tom" };
                User user2 = new User { Name = "Bob" };
                User user3 = new User { Name = "Sam" };

                Company company1 = new Company { Name = "Google", Users = { user1, user2 } };
                Company company2 = new Company { Name = "Microsoft", Users = { user3 } };

                db.Companies.AddRange(company1, company2); //Добавление компаний
                db.Users.AddRange(user1, user2, user3); //Добавление пользователейы
                db.SaveChanges();

                Console.WriteLine("Данные успешно добавлены");

                // получаем данные из бд
                foreach (var user in db.Users.ToList())
                {
                    Console.WriteLine($"{user.Name} работает в {user.Company?.Name} ");
                }
            }
        }
    }
}