using Microsoft.EntityFrameworkCore;
using Product_API_Azure.Contracts;
using Product_API_Azure.Data;
using Product_API_Azure.Models;

namespace Product_API_Azure.Repository
{
    public class ProductRepository : IProductRepo
    {
        ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var addedProduct=await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;

        }

        public async Task<bool> DeleteProduct(int id)
        {
           var deletedproduct=await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (deletedproduct != null)
            {
                _dbContext.Products.Remove(deletedproduct);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products=await _dbContext.Products.ToListAsync();
            return products;
        }
    }
}
