

using AutoMapper;
using ItemShop.Discount.DTOs.CouponDTOs;
using ItemShop.Discount.Entities;

namespace ItemShop.Discount.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Coupon, ResultCouponDto>().ReverseMap();
            CreateMap<Coupon, CreateCouponDto>().ReverseMap();
            CreateMap<Coupon, GetByIdCouponDto>().ReverseMap();
            CreateMap<Coupon, UpdateCouponDto>().ReverseMap();
        }
    }
}