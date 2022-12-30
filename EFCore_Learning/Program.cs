namespace EFCore_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                IEnumerable<User> userIEnum = db.Users;
                var users = userIEnum.Where(p => p.Id < 10).ToList();
                
                foreach(var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                IQueryable<User> userIQuer = db.Users;
                //var users = userIEnum.Where(p => p.Id < 10).ToList(); // Можно так
                userIQuer = userIQuer.Where(p => p.Id < 10);
                userIQuer = userIQuer.Where(p => p.Name == "Tom");
                var users = userIQuer.ToList();


                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
            /*Все зависит от конкретной ситуации.
             * Если разработчику нужен весь набор возвращаемых данных, то лучше использовать IEnumerable, 
             * предоставляющий максимальную скорость. Если же нам не нужен весь набор, а то только некоторые 
             * отфильтрованные данные, то лучше применять IQueryable.*/
        }
    }
}