using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Day13Demos.Models
{
    class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("data source=LAPTOP-53S2KQS8;initial catalog=USTPracticeDb;integrated security=true");
        }
    }
}
