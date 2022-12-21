using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Learning;

public partial class HelloappContext : DbContext
{
    public HelloappContext()
    {
    }

    public HelloappContext(DbContextOptions<HelloappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Motya\\Desktop\\TrainingBackend\\EFCore_Learning\\bin\\Debug\\net6.0\\helloapp.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
