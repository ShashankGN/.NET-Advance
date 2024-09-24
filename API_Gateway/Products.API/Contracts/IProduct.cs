using Products.API.Models;

namespace Products.API.Contracts
{
    public interface IProduct
    {
        public IEnumerable<Product> GetAllProducts();

        public Product GetById(Guid id);

        public Product AddProduct(Product product);

        public bool DeleteProduct(Guid id);

        public Product UpdateProduct(Guid id, Product product);
    }
}
