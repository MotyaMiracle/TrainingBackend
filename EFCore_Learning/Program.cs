namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Добавление данных
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                // создаем два объекта User
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                // Добавляем в БД
                db.Users.AddRange(user1, user2);
                db.SaveChanges(); 
            }
            
            // Получение данных
            using(ApplicationContext db = new ApplicationContext())
            {
                // Получаем объекты из БД и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Users list:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}