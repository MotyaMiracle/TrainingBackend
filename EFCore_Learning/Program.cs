using Microsoft.EntityFrameworkCore;

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

                Student tom = new Student { Name = "Tom" };
                Student sam = new Student { Name = "Sam" };
                Student alice = new Student { Name = "Alice" };
                db.Students.AddRange(tom, sam, alice);

                Course algorithms = new Course { Name = "Алгоритмы" };
                Course basics = new Course { Name = "Основы программирования" };
                db.Courses.AddRange(algorithms, basics);

                tom.Enrollments.Add(new Enrollments { Course = algorithms, Mark = 4 });
                tom.Courses.Add(basics);
                sam.Enrollments.Add(new Enrollments { Course = basics, Mark = 5 });
                alice.Enrollments.Add(new Enrollments { Course = algorithms });
                //algorithms.Students.AddRange(new List<Student>() { tom, sam }); // К курсу добавить студентов

                db.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
            }
            // Вывод данных
            using(ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Courses.Include(c => c.Students).ToList();
                foreach (Course course in courses)
                {
                    Console.WriteLine($"{course.Name}");
                    foreach(Student student in course.Students)
                    {
                        Console.WriteLine($"{student.Name}");
                    }
                    Console.WriteLine("---------");
                }
            }
            // Вывод через промежуточную сущность
            using (ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Courses.Include(c => c.Students).ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine($"{course.Name}");
                    foreach (var student in course.Enrollments)
                    {
                        Console.WriteLine($"{student.Student?.Name} - {student.Mark}");
                    }
                    Console.WriteLine("---------");
                }
            }
            // Обновление данных
            using (ApplicationContext db = new ApplicationContext())
            {
                Student? alice = db.Students.FirstOrDefault(s => s.Name == "Alice");
                Course? algorithms = db.Courses.FirstOrDefault(c => c.Name == "Алгоритмы")!;
                Course? basics = db.Courses.FirstOrDefault(c => c.Name == "Основы программирования")!;
                if (alice != null)
                {
                    alice.Courses.Remove(algorithms);
                    alice.Courses.Add(basics);
                    db.SaveChanges();
                }
            }
        }
    }
}