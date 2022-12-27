namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //User user1 = new User
                //{
                //    Login = "login1",
                //    Password = "1234",
                //    Profile = new UserProfile { Name = "Tom", Age = 33 }
                //};
                //User user2 = new User
                //{
                //    Login = "login2",
                //    Password = "5432",
                //    Profile = new UserProfile { Name = "Alice", Age = 26 }
                //};
                //User user1 = new User("login1", "1234", new UserProfile { Name = "Tom", Age = 33 });
                //User user2 = new User("login2", "5432", new UserProfile { Name = "Alice", Age = 26 });
                User user1 = new User
                {
                    Login = "login1",
                    Password = "1234",
                    Profile = new UserProfile
                    {
                        Name = new Claim { Key = "Name", Value = "Tom" },
                        Age = new Claim { Key = " Age", Value = "33" }
                    }
                };
                User user2 = new User
                {
                    Login = "login2",
                    Password = "5432",
                    Profile = new UserProfile
                    {
                        Name = new Claim { Key = "Name", Value = "Alice" },
                        Age = new Claim { Key = " Age", Value = "26" }
                    }
                };
                db.Users.AddRange(user1, user2);
                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
                // Получение данных
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Profile?.Name} - {u.Profile?.Age} - {u.Login} - {u.Password}");
                    //Console.WriteLine(u.ToString());
                    //Console.WriteLine($"{u.Profile?.Name?.Value} - {u.Profile?.Age?.Value} - {u.Login} - {u.Password}");
                }

            }
        }
    }
}