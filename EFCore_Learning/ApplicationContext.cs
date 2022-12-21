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
        readonly StreamWriter logStream = new StreamWriter("mylog.txt", true);
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = helloapp.db");
            //optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message)); Вывод логов в окно "Вывод"
            optionsBuilder.LogTo(logStream.WriteLine);
        }
        public override void Dispose()
        {
            base.Dispose();
            logStream.Dispose();
        }
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logStream.DisposeAsync();
        }
    }
}
