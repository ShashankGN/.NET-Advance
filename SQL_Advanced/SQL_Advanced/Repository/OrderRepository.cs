using Microsoft.EntityFrameworkCore;
using SQL_Advanced.Contracts;
using SQL_Advanced.DBContext;
using SQL_Advanced.Models;

namespace SQL_Advanced.Repository
{
    public class OrderRepository : IOrderRepository
    {
        CustomerDBContext _dbContext;
        public OrderRepository(CustomerDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> AddOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
      
        }


        public async Task<IEnumerable<Order>> GetOrders(int customerId)
        {
            //var customer=await _dbcontext.Orders.FindAsync(customerId);
            //return customer;
            throw new NotImplementedException();
        }
    }
}
