using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAppOne.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> EmployeeTable { get; set; }
    }
}
