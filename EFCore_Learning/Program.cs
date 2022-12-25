namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Company company1 = new Company { Name = "Microsoft" };
                Company company2 = new Company { Name= "Google" };

                User user1 = new User { Name = "Tom", Company = company2 };
                User user2 = new User { Name ="Alice", CompanyName = "Microsoft"};
                User user3 = new User { Name = "Sam", CompanyName = company1.Name };

                db.Companies.AddRange(company1, company1);
                db.Users.AddRange(user1, user2, user3);
                db.SaveChanges();

                foreach (var user in db.Users.ToList())
                {
                    Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");
                }

            }
        }
    }
}