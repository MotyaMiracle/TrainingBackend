namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // добавляем объекты в бд
                //db.Users.Add(new User {Name = "Tom" });
                //db.Users.Add(new User {Name = "Alice" });
                //User user1 = new User { Name = "Bob" };
                User user1 = new User { FirstName = "Bob", LastName = "Smith", Age = 36 };
                Console.WriteLine(user1.Name); // До добавления Name имеет значение по умолчанию
                //Console.WriteLine($"Age: {user1.Age}"); // 0
                db.Users.Add(user1);
                db.SaveChanges();
                Console.WriteLine(user1.Name); // Bob Smith
                db.Database.EnsureDeleted();
                //Console.WriteLine($"Age: {user1.Age} - {user1.CreateAt}"); // 18

                //var users = db.Users.ToList();
                //foreach(User user in users)
                //{
                //    Console.WriteLine($"{user.Id} - {user.Name}");
                //}
            }
        }
    }
}