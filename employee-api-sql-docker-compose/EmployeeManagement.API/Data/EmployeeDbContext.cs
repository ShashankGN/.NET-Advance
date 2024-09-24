using EmployeeManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Initial data creation
            var employeeOne = new Employee
            {
                Id = 1,
                Name = "Vijay",
                Email = "Vijay@test.com"

            };

            var employeeTwo = new Employee
            {
                Id = 2,
                Name = "Sujay",
                Email = "Sujay@test.com"

            };

            modelBuilder.Entity<Employee>().HasData(employeeOne, employeeTwo);
           
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
