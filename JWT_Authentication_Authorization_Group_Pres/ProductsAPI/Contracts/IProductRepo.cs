using ProductsAPI.Model;

namespace ProductsAPI.Contracts
{
    public interface IProductRepo
    {
        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product> AddProduct(Product product);


    }
}
