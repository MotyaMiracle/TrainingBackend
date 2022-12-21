using System.ComponentModel;

namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (HelloappContext db = new HelloappContext())
            {
                bool isCreated = db.Database.EnsureCreated();
                bool isAvalaible = db.Database.CanConnect();

                if (isCreated) Console.WriteLine("База данных была создана");
                else Console.WriteLine("База данных уже существует");
                if (isAvalaible) Console.WriteLine("К базе данных можно подключиться");
                else Console.WriteLine("К базе данных нельзя подключиться");

                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
                bool isDeleted = db.Database.EnsureDeleted();
                if (isDeleted) Console.WriteLine("База данных удалена");
                else Console.WriteLine("Базы данных нет");
                if (isAvalaible) Console.WriteLine("К базе данных можно подключиться");
                else Console.WriteLine("К базе данных нельзя подключиться");

            }
        }
    }
}