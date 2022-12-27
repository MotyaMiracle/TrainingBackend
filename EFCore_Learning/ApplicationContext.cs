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


        public ApplicationContext() 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=322228");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().OwnsOne(u => u.Profile);
            //modelBuilder.Entity<User>().OwnsOne(typeof(UserProfile), "Profile"); //Если приватный тип
            modelBuilder.Entity<User>().OwnsOne(u => u.Profile, p =>
            {
                p.OwnsOne(c => c.Name);
                p.OwnsOne(c => c.Age);
            });
        }
        
    }
}
