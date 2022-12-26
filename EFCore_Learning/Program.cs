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

                Company microsoft = new Company { Name= "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);
                
                User tom = new User { Name = "Tom", Company = microsoft };
                User sam = new User { Name = "Sam", Company = google };
                User alice = new User { Name = "Alice", Company = microsoft };
                User kate = new User { Name = "Kate", Company = google };
                db.Users.AddRange(tom, sam, alice, kate);
                
                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
            }
            using(ApplicationContext db = new ApplicationContext())
            {
                Company? company = db.Companies.FirstOrDefault();
                if (company != null)
                {
                    //db.Users.Where(u => u.CompanyId == company.Id).Load(); // Если без условия то можно было db.Users.Load()
                    //Метод Collection применяется, если навигационное свойство представляет коллекцию
                    db.Entry(company).Collection(c => c.Users).Load();

                    Console.WriteLine($"Company: {company.Name}");
                    foreach(var user in company.Users)
                    {
                        Console.WriteLine($"User: {user.Name}");
                    }
                }
            }
            using(ApplicationContext db = new ApplicationContext())
            {
                User? user = db.Users.FirstOrDefault();
                if(user != null)
                {
                    //Если навигационное свойство представляет одиночный объект, то можно применять метод Reference:
                    db.Entry(user).Reference(u => u.Company).Load();
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
                }
            }
        }
    }
}