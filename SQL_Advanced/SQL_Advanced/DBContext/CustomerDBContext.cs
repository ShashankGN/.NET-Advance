using Microsoft.EntityFrameworkCore;
using SQL_Advanced.Models;

namespace SQL_Advanced.DBContext
{
    public class CustomerDBContext:DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options):base(options) 
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer
                {
                    CustomerId = 1,
                    Name = "Arun"
                },
                new Customer
                {
                    CustomerId= 2,
                    Name="Bunty"
                }
                );
            modelBuilder.Entity<Order>()
                .HasData(
                new Order
                {
                    OrderId = 1,
                    CustomerId = 1,
                    ProductName = "Mobile"
                },
                new Order
                {
                    OrderId = 2,
                    CustomerId = 2,
                    ProductName = "Laptop"
                },
                new Order
                {
                    OrderId = 3,
                    CustomerId = 1,
                    ProductName = "Fan"
                }          
                );
        }
    }
}
