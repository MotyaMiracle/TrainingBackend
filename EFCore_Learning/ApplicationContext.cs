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
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=322228");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Создание индекса
            modelBuilder.Entity<User>().HasIndex(u => u.Passport);
            // Указание уникальности индекса
            //modelBuilder.Entity<User>().HasIndex(u => u.Passport).IsUnique();
            // Составной индекс
            //modelBuilder.Entity<User>().HasIndex(u => new { u.Passport, u.PhoneNumber });
            // Установка имени индекса
            //modelBuilder.Entity<User>().HasIndex(u => u.PhoneNumber)
            //    .HasDatabaseName("PhoneIndex");
            // Фильтры индексов, работают если индекс создан
            //modelBuilder.Entity<User>()
            //    .HasIndex(u => u.PhoneNumber)
            //    .HasFilter("[PhoneNumber] IS NOT NULL");
        }

    }
}
