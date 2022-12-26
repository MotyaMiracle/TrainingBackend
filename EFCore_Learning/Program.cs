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

                //Добавляем начальные данные
                Position developer = new Position { Name = "Developer" };
                Position manager = new Position { Name = "Manager" };
                db.Positions.AddRange(developer, manager);

                City washington = new City { Name = "Washington" };
                City tokyo = new City { Name = "Tokyo" };
                db.Cities.AddRange(washington, tokyo);

                Country usa = new Country { Name = "USA", Capital = washington };
                Country japan = new Country { Name = "Japan", Capital = tokyo };
                db.Countries.AddRange(usa, japan);

                Company microsoft = new Company { Name = "Microsoft", Country = usa };
                Company sony = new Company { Name = "Sony", Country = japan };
                db.Companies.AddRange(microsoft, sony);

                User tom = new User { Name = "Tom", Company = microsoft, Position = manager };
                User bob = new User { Name = "Bob", Company = sony, Position = developer };
                User alice = new User { Name = "Alice", Company = microsoft, Position = manager };
                User kate = new User { Name = "Kate", Company = sony, Position = developer };
                db.Users.AddRange(tom, bob, alice, kate);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

                //// получаем пользователей
                //var users = db.Users
                //    .Include(u => u.Company) // Нет смысла, так как мы добавили в этом же контексте
                //    .ToList();
                //foreach (var user in users)
                //{
                //    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
                //}
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users
                    .Include(u => u.Company!.Country!.Capital) //Можно так вместо .ThenInclude
                        //.ThenInclude(comp => comp!.Country) // Можно было заменить на .Include(u => u.Company!.Country!.Capital)
                        //    .ThenInclude(coun => coun!.Capital)// к компаниям подгружаем данные по странам
                    .Include(u => u.Position)
                    .ToList();
                foreach(var user in users)
                {
                    Console.WriteLine($"{user.Name} - {user.Position?.Name}");
                    Console.WriteLine($"{user.Company?.Name} - {user.Company?.Country?.Name} - {user.Company?.Country?.Capital?.Name}");
                }
                Console.WriteLine("--------");
            }
            using(ApplicationContext db = new ApplicationContext())
            {
                var companies = db.Companies
                    .Include(c => c.Users) // Добавляем данные по пользователям
                    .ToList();
                foreach (var company in companies)
                {
                    Console.WriteLine(company.Name);
                    // Выводим сотрудников
                    foreach(var user in company.Users)
                    {
                        Console.WriteLine(user.Name);
                    }
                    Console.WriteLine("--------");
                }
            }
        }
    }
}