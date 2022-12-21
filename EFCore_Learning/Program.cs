using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsetting.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection")!;

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlite(connectionString).Options;

            /*using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.Migrate(); // Миграция, нельзя испольозовать в связке Database.EnsureCreate
            }*/

            using (ApplicationContext db = new ApplicationContext(options))
            {
                // создаем два объекта
                User tom = new User { Name = "Tom", Age = 33 };
                User alice = new User { Name = "Alice", Age = 26 };
                
                // добавляем объекты в бд
                db.Users.Add(tom);
                db.Users.Add(alice);
                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

                // получаем данные из бд
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}