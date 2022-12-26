using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Learning
{
    public  class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;


        public ApplicationContext() 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder
                .UseLazyLoadingProxies() // Подключение к Lazy Loading
                .UseNpgsql("Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=322228");
        }
        
    }
}
