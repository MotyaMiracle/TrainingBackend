using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Learning;

public partial class HelloappContext : DbContext
{
    public HelloappContext() => Database.EnsureCreated();

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}
