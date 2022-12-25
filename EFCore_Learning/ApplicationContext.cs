using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            // Определение конфигурации при помощи методов
            //modelBuilder.Entity<User>(UserConfigure);
            //modelBuilder.Entity<Company>(CompanyConfigure);
        }
        // Конфигурация для типа User
        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("People").Property(p => p.Name).IsRequired();
            builder.Property(p => p.Id).HasColumnName("user_id");
        }
        // Конфигуратор для типа Company
        public void CompanyConfigure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Enterprises").Property(c => c.Name).IsRequired();
        }
    }
}
