namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта
                User tom = new User { Name = "Tom", Passport = "1234", PhoneNumber = "5678" };
                User alice = new User { Name = "Alice", Passport = "4321", PhoneNumber = "8765" };
                
                // добавляем объекты в бд
                db.Users.Add(tom);
                db.Users.Add(alice);
                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

                // получаем данные из бд
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Passport} - {u.PhoneNumber}");
                }
            }
        }
    }
}