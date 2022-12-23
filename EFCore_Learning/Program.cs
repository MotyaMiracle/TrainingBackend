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
                // создаем два объекта
                User tom = new User("Tom", 33);
                User bob = new User("Bob", 41);
                
                // добавляем объекты в бд
                db.Users.Add(tom);
                db.Users.Add(bob);
                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
            }
            using(ApplicationContext db = new ApplicationContext())
            {
                // получаем данные из бд
                var users = db.Users.ToList();
                Console.WriteLine("Получение данных из БД");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Name} - {u.Age}");
                }
            }
        }
    }
}