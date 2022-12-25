namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта
                User tom = new User { Name = "Tom", Age = 33 };
                User alice = new User { Name = "Alice", Age = 26 };
                User bob = new User { Name = "Bob", Age = 119 };
                // добавляем объекты в бд
                db.Users.Add(tom);
                db.Users.Add(alice);
                db.Users.Add(bob); //Нельзя т.к Bob не проходит ограничение CHECK
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