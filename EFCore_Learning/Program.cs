namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (HelloappContext db = new HelloappContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }
    }
}