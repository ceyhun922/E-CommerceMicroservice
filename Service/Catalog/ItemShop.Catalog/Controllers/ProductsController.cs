using ItemShop.Catalog.DTOs.ProductDTOs;
using ItemShop.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Catalog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

     public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products-list")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpPost("product-create")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            await _productService.CreateProductAsync(dto);
            return Ok("eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
              if (string.IsNullOrEmpty(id) || id.Length != 24)
                return BadRequest("Geçersiz ID formatı");
            var value = await _productService.GetByIdProductAsync(id);

            if (value == null)
            {
                return Ok(new { message = "Bulunamadı" });
            }
            return Ok(value);
        }

        [HttpPut("product-update")]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            await _productService.UpdateProductAsync(dto);
            return Ok("Güncellendi");
        }

        [HttpDelete("product-delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 24)
                return BadRequest("Geçersiz ID formatı");
                
            var value = await _productService.GetByIdProductAsync(id);
            if (value == null)
                return NotFound("Kategori bulunamadı");

            await _productService.RemoveProductAsync(id);
            return Ok("Silindi");
        }
    }
}