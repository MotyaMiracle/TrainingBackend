using System.Runtime.CompilerServices;

namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Добавление (SQL выражение INSERT)
            using(ApplicationContext db = new ApplicationContext())
            {
                User tom = new User {Name = "Tom", Age = 33 };
                User alice = new User { Name = "Alice", Age = 26 };
                User maxim = new User { Name = "Maxim", Age = 20 };
                User nikita = new User { Name = "Nikita", Age = 19 };
                User alex = new User { Name = "Alexander", Age = 21 };

                // Добавление
                db.Users.Add(tom);
                db.Users.Add(alice);
                db.Users.AddRange(maxim, alex, nikita); // Добавляются несколько, по указанному порядку
                db.SaveChanges();
            }

            // Получение
            using(ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // Редактирование (SQL выражение UPDATE)
            using (ApplicationContext db = new ApplicationContext())
            {
                // Получаем первый объект
                User? user = db.Users.FirstOrDefault();
                User? fourUser = db.Users.FirstOrDefault(u => u.Id == 4)!;
                User? secondUser = db.Users.FirstOrDefault(u => u.Id == 2)!;
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    secondUser.Name = "Valeria";
                    secondUser.Age = 18;
                    fourUser.Name = "Danil";
                    fourUser.Age = 22;
                    // Обновляем объект
                    db.Users.Update(user);
                    // Обновление нескольких объектов
                    db.Users.UpdateRange(fourUser, secondUser);
                    db.SaveChanges();
                }
                // Выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var users = db.Users.ToList();
                foreach  (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            // Удаление (SQL выражение DELETE)
            using (ApplicationContext db = new ApplicationContext())
            {
                // Получаем первый объект
                User? user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    // Удаляем объкет
                    db.Remove(user);
                    db.SaveChanges();
                }
                // Удаляем несколько
                User? thirdUser = db.Users.FirstOrDefault(u => u.Id == 3);
                User? fiveUser = db.Users.FirstOrDefault(u => u.Id == 5);
                if (thirdUser != null && fiveUser != null)
                {
                    db.Users.RemoveRange(thirdUser, fiveUser);
                    db.SaveChanges();
                }
                Console.WriteLine("\nВыводим данные после удаления:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}