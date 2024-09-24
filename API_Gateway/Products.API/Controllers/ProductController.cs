using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.API.Contracts;
using Products.API.Models;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _product.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetAllProducts([FromRoute]Guid id)
        {
            var product = _product.GetById(id);
            if (product == null)
            {
                return NotFound($"Product with id {id} is not found");
            }
            return Ok(product);
        }


        [HttpPost]
        public IActionResult AddProducts([FromBody]Product product)
        {
            var prod = _product.AddProduct(product);
            return Ok(prod);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducts([FromRoute]Guid id)
        {
            var prod= _product.DeleteProduct(id);
            if (prod)
            {
                return Ok($"Product with id {id} deleted successfully!");
            }
            return NotFound($"Product with id {id} is not found");

        }

        [HttpPut("{id}")]

        public IActionResult UpdateProduct([FromRoute]Guid id, [FromBody]Product products)
        {
            var prod=_product.UpdateProduct(id, products);
            if (prod != null)
            {
                return Ok($"updated product: {prod}");
            }
            return NotFound($"Product with id {id} is not found");
        }

        
    }
}
