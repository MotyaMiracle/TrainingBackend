using Microsoft.EntityFrameworkCore;

namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user1 = db.Users.FirstOrDefault();
                var user2 = db.Users.AsNoTracking().FirstOrDefault();
                if (user1 != null && user2 != null)
                {
                    Console.WriteLine($"Before User1: {user1.Name} User2: {user2.Name}");

                    user1.Name = "Bob";

                    Console.WriteLine($"After User1: {user1.Name} User2: {user2.Name}");
                }

            }
        }
    }
}