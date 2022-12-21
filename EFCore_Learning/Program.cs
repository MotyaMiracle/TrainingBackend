using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var builder = new ConfigurationBuilder();
            // Установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // Получение конфигурации из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // Создаем конфигурации
            var config = builder.Build();
            // Получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection")!;
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var options = optionsBuilder.UseSqlite(connectionString).Options; // Либо в connectionString закинуть прямую ссылку на файл.db

            using (ApplicationContext db = new ApplicationContext(options)) //В параметры закинуть connectionString или options
            {
                Console.WriteLine("Пользователи:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}