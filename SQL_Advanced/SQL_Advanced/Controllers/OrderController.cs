using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQL_Advanced.Contracts;
using SQL_Advanced.Models;

namespace SQL_Advanced.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders= await _orderRepository.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            var added_order = await _orderRepository.AddOrder(order);
            return Ok(added_order);
        }
    }
}
