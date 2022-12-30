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

                Role adminRole = new Role { Name = "Admin" };
                Role userRole = new Role { Name = "User" };

                User user1 = new User { Name = "Tom", Age = 17, Role = userRole };
                User user2 = new User { Name = "Sam", Age = 18, Role = userRole };
                User user3 = new User { Name = "Alice", Age = 19, Role = adminRole };
                User user4 = new User { Name = "Sam", Age = 20, Role = adminRole };

                db.Roles.AddRange(userRole, adminRole);
                db.Users.AddRange(user1, user2, user3, user4);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
            }
            using(ApplicationContext db = new ApplicationContext() { RoleId = 2})
            {
                var users = db.Users.Include(u => u.Role).ToList();
                foreach(User user in users)
                {
                    Console.WriteLine($"Name: {user.Name}  Age: {user.Age}  Role: {user.Role?.Name}");
                }
                Console.WriteLine();
            }
            using(ApplicationContext db = new ApplicationContext() { RoleId = 2 })
            {
                int minAge = db.Users.Min(u => u.Age);
                Console.WriteLine(minAge);
            }
            using (ApplicationContext db = new ApplicationContext() { RoleId = 2 })
            {
                // Если необходимо во время запроса отключить фильтр
                int minAge = db.Users.IgnoreQueryFilters().Min(u => u.Age);
                Console.WriteLine(minAge);
            }
        }
    }
}