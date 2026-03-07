using ItemShop.Catalog.DTOs.ProductImageDTOs;
using ItemShop.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

     public class ProductImagesController
 : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("products-image-list")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpPost("product-image-create")]
        public async Task<IActionResult> Create(CreateProductImageDto dto)
        {
            await _productImageService.CreateProductImageAsync(dto);
            return Ok("eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
              if (string.IsNullOrEmpty(id) || id.Length != 24)
                return BadRequest("Geçersiz ID formatı");
            var value = await _productImageService.GetByIdProductImage(id);
            if (value == null)
            {
                return Ok(new { message = "Bulunamadı" });
            }
            return Ok(value);
        }

        [HttpPut("product-image-update")]
        public async Task<IActionResult> Update(UpdateProductImageDto dto)
        {
            await _productImageService.UpdateProductImageAsync(dto);
            return Ok("Güncellendi");
        }

        [HttpDelete("product-image-delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 24)
                return BadRequest("Geçersiz ID formatı");
                
            var value = await _productImageService.GetByIdProductImage(id);
            if (value == null)
                return NotFound("Kategori bulunamadı");

            await _productImageService.DeleteProductImageasync(id);
            return Ok("Silindi");
        }
    }
}