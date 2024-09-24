using Employees.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.API.DBContext
{
    public class EmployeeDBContext:DbContext
    {
        public EmployeeDBContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Employee>Employees { get; set; }
    }
}
