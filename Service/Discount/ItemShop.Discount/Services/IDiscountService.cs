using ItemShop.Discount.DTOs.CouponDTOs;

namespace ItemShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();

        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);

        Task<GetByIdCouponDto> GetByIdCoupon(int id);
    }
}