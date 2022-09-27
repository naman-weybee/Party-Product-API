using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyProductUsingAPI.Models;
using PartyProductUsingAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductUsingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository = null;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Product()
        {
            var data = await _productRepository.GetAllProduct();
            return Ok(data);
        }

        [HttpPost("")]
        public async Task<IActionResult> ProductAdd([FromBody] Product product)
        {
            var data = await _productRepository.ProductAddAsync(product);
            return CreatedAtAction(nameof(ProductAdd), new { controller = "Product" }, data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct([FromRoute] int id, [FromBody] Product product)
        {
            var data = await _productRepository.EditProductAsync(id, product);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return Ok();
        }
    }
}
