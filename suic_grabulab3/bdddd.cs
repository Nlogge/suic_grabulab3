using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace suic_grabulab3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Stock> Stocks => Set<Stock>();

        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AllCars.db");
        }
    }
}
