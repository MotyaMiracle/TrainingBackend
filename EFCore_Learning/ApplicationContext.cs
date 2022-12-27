using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;

namespace EFCore_Learning
{
    public  class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;

        public ApplicationContext() 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=322228");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity<Enrollments>(
                    j => j
                    .HasOne(pt => pt.Student)
                    .WithMany(t => t.Enrollments)
                    .HasForeignKey(pt => pt.StudentId),
                    j => j
                    .HasOne(pt => pt.Course)
                    .WithMany(t => t.Enrollments)
                    .HasForeignKey(pt => pt.CourseId),
                    j =>
                    {
                        j.Property(pt => pt.Mark).HasDefaultValue(3);
                        j.HasKey(t => new { t.CourseId, t.StudentId });
                        j.ToTable("Enrollments");
                    });
        }
        
    }
}
