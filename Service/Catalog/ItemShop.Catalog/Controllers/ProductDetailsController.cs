
using ItemShop.Catalog.DTOs.ProductDetailDTOs;
using ItemShop.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

     public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet("products-detail-list")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpPost("product-detail-create")]
        public async Task<IActionResult> Create(CreateProductDetailDto dto)
        {
            await _productDetailService.CreateProductDetailAsync(dto);
            return Ok("eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
              if (string.IsNullOrEmpty(id) || id.Length != 24)
                return BadRequest("Geçersiz ID formatı");
            var value = await _productDetailService.GetByIdProductDetail(id);
            if (value == null)
            {
                return Ok(new { message = "Bulunamadı" });
            }
            return Ok(value);
        }

        [HttpPut("product-detail-update")]
        public async Task<IActionResult> Update(UpdateProductDetailDto dto)
        {
            await _productDetailService.UpdateProductDetailAsync(dto);
            return Ok("Güncellendi");
        }

        [HttpDelete("product-detail-delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 24)
                return BadRequest("Geçersiz ID formatı");
                
            var value = await _productDetailService.GetByIdProductDetail(id);
            if (value == null)
                return NotFound("Kategori bulunamadı");

            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Silindi");
        }
    }
}