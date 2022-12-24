namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта
                //User tom = new User { Name = "Tom", PassportSeria = "4321",PassportNumber = "12345678" };
                //User alice = new User { Name = "Alice", PassportSeria = "1234" ,PassportNumber = "87654321" };
                //User tom = new User { Name = "Tom", Age = 33 };
                //User alice = new User { Name = "Alice", Age = 26 };
                //User tom = new User { Name = "Tom", PhoneNumber = "987654321", Age = 33 };
                //User alice = new User { Name = "Alice", PhoneNumber = "123456789", Age = 26 };
                User tom = new User { Name = "Tom", Passport = "123456789", PhoneNumber = "987654321", Age = 33 };
                User alice = new User { Name = "Alice", Passport = "987654321", PhoneNumber = "123456789", Age = 26 };


                // добавляем объекты в бд
                db.Users.Add(tom);
                db.Users.Add(alice);
                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");

                // получаем данные из бд
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    //Console.WriteLine($"{u.Identy}.{u.Name} - {u.Age}");
                    //Console.WriteLine($"{u.PassportSeria}.{u.PassportNumber} - {u.Name}");
                    //Console.WriteLine($"{u.Identy}.{u.Name} - {u.Age} - {u.PhoneNumber}");
                    Console.WriteLine($"{u.Identy}.{u.Name} - {u.Age} - {u.Passport} - {u.PhoneNumber}");
                }
            }
        }
    }
}