using Microsoft.EntityFrameworkCore;
using ProductsAPI.Contracts;
using ProductsAPI.Data;
using ProductsAPI.Model;

namespace ProductsAPI.Repo
{
    public class ProductRepository : IProductRepo
    {
        ProductDBcontext _dBcontext;
        public ProductRepository(ProductDBcontext context)
        {
            _dBcontext = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await _dBcontext.Products.AddAsync(product);
            await _dBcontext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            //throw new Exception("Error while accessing the get request");
            return await _dBcontext.Products.ToListAsync();
        }
    }
}
