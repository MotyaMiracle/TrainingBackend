namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта
                User bob = new User("Bob", 30);
                User kate = new User("Kate", 29);
                
                // добавляем объекты в бд
                db.Users.Add(bob);
                db.Users.Add(kate);
                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

                // получаем данные из бд
                var users = db.Users.ToList();
                foreach (User user in users)
                {
                    user.Print();
                }
            }
        }
    }
}