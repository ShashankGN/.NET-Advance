using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SQL_Advanced.Contracts;

namespace SQL_Advanced.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomer();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Models.Customer customer)
        {
            var added_customer=await _customerRepository.AddCustomer(customer);
            return Ok(added_customer);
        }



    }
}
