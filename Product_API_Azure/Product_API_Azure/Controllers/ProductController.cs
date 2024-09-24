using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_API_Azure.Contracts;
using Product_API_Azure.Models;

namespace Product_API_Azure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products=await _productRepo.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Product product)
        {
            var addedproduct=await _productRepo.AddProduct(product);
            return Ok(addedproduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var deletedproduct=await _productRepo.DeleteProduct(id);
            if (deletedproduct)
            {
                return Ok($"Product with Id {id} is deleted");
            }
            else
            {
                return NotFound("product is not found");
            }
        }
    }
}
