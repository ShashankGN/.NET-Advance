using SQL_Advanced.Models;

namespace SQL_Advanced.Contracts
{
    public interface ICustomerRepository
    {
        public Task<Customer> AddCustomer(Customer customer);

        public Task<IEnumerable<Customer>> GetAllCustomer();

        
    }
}
