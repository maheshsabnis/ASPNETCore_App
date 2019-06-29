using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CoreAppHome.Models
{
    public class AppHomeDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// The DbContextOptions will read the DbCOntext Meta info
        /// e.g. Connection String from DI Container
        /// </summary>
        /// <param name="options"></param>
        public AppHomeDbContext(DbContextOptions<AppHomeDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
