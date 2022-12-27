using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

                //Добавляем начальные данные
                MenuItem file = new MenuItem { Title = "File" };
                MenuItem edit = new MenuItem { Title = "Edit" };
                MenuItem open = new MenuItem { Title = "Open", Parent = file };
                MenuItem save = new MenuItem { Title = "Save", Parent = file };

                MenuItem copy = new MenuItem { Title = "Cope", Parent = edit };
                MenuItem paste = new MenuItem { Title = "Paste", Parent = edit };
                db.MenuItems.AddRange(file, edit, open, save, copy, paste);

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
            }
            // Получаем данные
            using(ApplicationContext db = new ApplicationContext())
            {
                // Получаем все пункты меню
                var menuItems = db.MenuItems.ToList();
                foreach(MenuItem m in menuItems)
                {
                    Console.WriteLine(m.Title);
                }
                Console.WriteLine();
                // Получаем определенный пункт меню с подменю
                var fileMenu = db.MenuItems.FirstOrDefault(m => m.Title == "File");
                if(fileMenu != null)
                {
                    Console.WriteLine(fileMenu.Title);
                    foreach(var m in fileMenu.Children)
                    {
                        Console.WriteLine($"---{m.Title}");
                    }
                }
            }
        }
    }
}