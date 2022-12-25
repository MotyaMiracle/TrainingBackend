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
            // Определяем компании
            Company microsoft = new Company { Id = 1, Name = "Microsoft" };
            Company google = new Company { Id = 2, Name = "Google" };
            // Определяем пользователей
            User tom = new User { Id = 1, Name = "Tom", Age = 23, CompanyId = microsoft.Id };
            User alice = new User { Id = 2, Name = "Alice", Age = 26, CompanyId = microsoft.Id };
            User sam = new User { Id = 3, Name = "Sam", Age = 28, CompanyId = google.Id };

            // Добавляем данные для обеих сущностей
            modelBuilder.Entity<User>().HasData(tom, alice, sam);
            modelBuilder.Entity<Company>().HasData(microsoft, google);
        }
    }
}
