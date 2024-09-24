using Microsoft.EntityFrameworkCore;
using ProductsAPI.Model;

namespace ProductsAPI.Data
{
    public class ProductDBcontext:DbContext
    {
        public ProductDBcontext(DbContextOptions<ProductDBcontext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
