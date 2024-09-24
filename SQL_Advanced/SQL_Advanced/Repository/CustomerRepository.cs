using Microsoft.EntityFrameworkCore;
using SQL_Advanced.Contracts;
using SQL_Advanced.DBContext;
using SQL_Advanced.Models;

namespace SQL_Advanced.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerDBContext _dbcontext;
        public CustomerRepository(CustomerDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _dbcontext.Customers.AddAsync(customer);
            await _dbcontext.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _dbcontext.Customers.ToListAsync();
        }

        
    }
}
