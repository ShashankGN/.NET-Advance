using Microsoft.EntityFrameworkCore;
using Product_API_Azure.Models;

namespace Product_API_Azure.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options) 
        {
           
        }

        public DbSet<Product> Products { get; set; }
    }
}
