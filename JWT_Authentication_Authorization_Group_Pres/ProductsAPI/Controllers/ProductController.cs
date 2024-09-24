using Jwt_Authenticatoin_Authorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Contracts;
using ProductsAPI.Model;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _context;
        public ProductController(IProductRepo context) {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var product =await _context.GetProducts();
            return Ok(product);
        }

        [Authorize(Roles =UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var addProduct= await _context.AddProduct(product);
            return Ok(addProduct);
        }
        
    }
}
