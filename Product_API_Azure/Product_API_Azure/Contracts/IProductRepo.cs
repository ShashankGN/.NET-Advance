using Product_API_Azure.Models;

namespace Product_API_Azure.Contracts
{
    public interface IProductRepo
    {
        public Task<IEnumerable<Product>> GetAllProducts();

        public Task<Product> AddProduct(Product product);
        public Task<bool> DeleteProduct(int id);

    }
}
