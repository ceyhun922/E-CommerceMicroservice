

using ItemShop.Catalog.DTOs.CatgoryDTOs;
using ItemShop.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Catalog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories-list")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpPost("category-create")]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            await _categoryService.CreateCategoryAsync(dto);
            return Ok("eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
              if (string.IsNullOrEmpty(id) || id.Length != 24)
                return BadRequest("Geçersiz ID formatı");
            var value = await _categoryService.GetByIdCategoryAsync(id);

            if (value == null)
            {
                return Ok(new { message = "Bulunamadı" });
            }
            return Ok(value);
        }

        [HttpPut("category-update")]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            await _categoryService.UpdateCategoryAsync(dto);
            return Ok("Güncellendi");
        }

        [HttpDelete("category-delete")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 24)
                return BadRequest("Geçersiz ID formatı");
                
            var value = await _categoryService.GetByIdCategoryAsync(id);
            if (value == null)
                return NotFound("Kategori bulunamadı");

            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Silindi");
        }
    }
}