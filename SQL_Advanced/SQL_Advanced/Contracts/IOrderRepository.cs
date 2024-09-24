using SQL_Advanced.Models;

namespace SQL_Advanced.Contracts
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetAllOrders();
        public Task<Order> AddOrder(Order order);

        public Task<IEnumerable<Order>> GetOrders(int customerId);
    }
}
