
using ItemShop.Discount.DTOs.CouponDTOs;
using ItemShop.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Discount.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _service;

        public DiscountsController(IDiscountService service)
        {
            _service = service;
        }

        [HttpGet("discounts-list")]

        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _service.GetAllCouponsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _service.GetByIdCoupon(id);

            if (value == null)
            {
                return Ok("Bulunamadı");
            }
            return Ok(value);
        }

        [HttpPost("discount-create")]
        public async Task<IActionResult> CreateAsync(CreateCouponDto createCouponDto)
        {
            await _service.CreateCouponAsync(createCouponDto);
            return Ok("eklendi");
        }

        [HttpPut("discount-update")]
        public async Task<IActionResult> UpdateAsync(UpdateCouponDto updateCouponDto)
        {
            await _service.UpdateCouponAsync(updateCouponDto);
            if (updateCouponDto.CouponId == null)
            {
                return Ok("Bulunamadı");
            }
            return Ok("güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var value =await _service.GetByIdCoupon(id);
            if (value == null)
            {
                 return Ok("Bulunamadı");
            }

            await _service.DeleteCouponAsync(value.CouponId);
            return Ok("Silindi");
        }
    }
}