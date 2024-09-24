using Products.API.Contracts;
using Products.API.Data;
using Products.API.Models;

namespace Products.API.Repository
{
    public class ProductInMemoryRepository : IProduct
    {
        ProductDbContext _context;
        public ProductInMemoryRepository(ProductDbContext context)
        {
            _context = context;
        }
        public Product AddProduct(Product product)
        {
            var prod=_context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool DeleteProduct(Guid id)
        {
            var product=_context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetById(Guid id)
        {
            var prod= _context.Products.FirstOrDefault(y => y.Id == id);
            if(prod != null)
            {
                return prod;
            }
            return null;
        }

        public Product UpdateProduct(Guid id, Product product)
        {
            var prod= _context.Products.FirstOrDefault(y => y.Id == id);
            if (prod != null)
            {
                prod.Name = product.Name;
                prod.Price = product.Price;
                _context.SaveChanges();
                return prod;
            }
            return null;
        }

    }
}
