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
            modelBuilder.Entity<User>().HasKey(u => u.Identy);
            // Настройка имени ограничения для первичного ключа
            //modelBuilder.Entity<User>().HasKey(u => u.Identy).HasName("UsersPrimaryKey");
            // Создание составного ключа
            //modelBuilder.Entity<User>().HasKey(u => new { u.PassportSeria, u.PassportNumber });
            // Создание альтернативного ключа (Свойства, которые должны иметь уникальные значения)
            //modelBuilder.Entity<User>().HasAlternateKey(u => u.PhoneNumber);
            // Создание составного альтернативного ключа
            modelBuilder.Entity<User>().HasAlternateKey(u => new { u.Passport, u.PhoneNumber });


        }
    }
}
