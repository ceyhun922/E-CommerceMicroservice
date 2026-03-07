namespace ItemShop.Discount.DTOs.CouponDTOs
{
    public class UpdateCouponDto
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public string Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}