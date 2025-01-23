using Microsoft.AspNetCore.Mvc;
using WebAPIProject.Server.Models;
using WebAPIProject.Server.Repository;

namespace WebAPIProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPro()
        {
            var products = await _productRepository.GetPro();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddPro(Product product)
        {
            await _productRepository.SavePro(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePro(int id)
        {
            var pro = await _productRepository.GetProById(id);
            if (pro == null)
            {
                return NotFound(new { Message = "Product not found" });
            }
            await _productRepository.DeletePro(id);
            return Ok(new { Message = "Product deleted successfully" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePro(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(new { Message = "Product Id mismatch" });
            }
            var existingPro = await _productRepository.GetProById(product.Id);
            if (existingPro == null)
            {
                return NotFound(new { Message = "Product not found" });
            }
            await _productRepository.UpdatePro(product);
            return Ok(new { Message = "Product updated successfully" });
        }
    }
}
