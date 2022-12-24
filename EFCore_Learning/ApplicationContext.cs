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
            // Отключение автогенерации значения для свойства с помощью Fluent API
            //modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedNever();
            // Установка значений по умолчанию (для свойств типа int)
            //modelBuilder.Entity<User>().Property(u => u.Age).HasDefaultValue(18);
            /*Определяет генерацию значения по умолчанию, только само значение 
             * устанавливается на основе кода SQL, который передается в этот метод.*/
            //modelBuilder.Entity<User>().Property(u => u.CreateAt)
            //    .HasDefaultValueSql("CURRENT_DATE + CURRENT_TIME");
            // Объединение свойств
            modelBuilder.Entity<User>().Property(u => u.Name)
                .HasComputedColumnSql("FirstName || ' ' || LastName");
        }
        
    }
}
