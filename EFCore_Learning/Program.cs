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

                User user1 = new User { Login = "login1", Password = "pass1234" };
                User user2 = new User { Login = "login2", Password = "1234pass" };
                db.Users.AddRange(user1, user2);

                UserProfile profile1 = new UserProfile { Name = "Tom", Age = 33, User = user1 };
                UserProfile profile2 = new UserProfile { Name = "Alice", Age = 26, User = user2 };
                db.UserProfiles.AddRange(profile1, profile2);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

            }
            // Получение данных
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach(User user in db.Users.Include(u => u.Profile).ToList())
                {
                    Console.WriteLine($"Name: {user.Profile?.Name} Age: {user.Profile?.Age} ");
                    Console.WriteLine($"Login: {user.Login} Password: {user.Password} \n");
                }
            }
            // Изменение данных
            using(ApplicationContext db = new ApplicationContext())
            {
                User? user = db.Users.FirstOrDefault();
                if(user != null)
                {
                    user.Password = "abc123";
                    db.SaveChanges();
                }
                UserProfile? profile = db.UserProfiles.FirstOrDefault(p => p.User!.Login == "login2");
                if(profile != null)
                {
                    profile.Name = "Alice II";
                    db.SaveChanges();
                }
                foreach (User u in db.Users.Include(u => u.Profile).ToList())
                {
                    Console.WriteLine($"Name: {u.Profile?.Name} Age: {u.Profile?.Age} ");
                    Console.WriteLine($"Login: {u.Login} Password: {u.Password} \n");
                }
            }
            // Удаление первый объект User
            using(ApplicationContext db = new ApplicationContext())
            {
                User? user = db.Users.FirstOrDefault();
                if(user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                // Удаляем объект UserProfile с логином login2
                UserProfile? profile = db.UserProfiles.FirstOrDefault(p => p.User!.Login == "login2");
                if(profile != null)
                {
                    db.UserProfiles.Remove(profile);
                    db.SaveChanges();
                }
                foreach (User u in db.Users.Include(u => u.Profile).ToList())
                {
                    Console.WriteLine($"Name: {u.Profile?.Name} Age: {u.Profile?.Age} ");
                    Console.WriteLine($"Login: {u.Login} Password: {u.Password} \n");
                }
            }
        }
    }
}