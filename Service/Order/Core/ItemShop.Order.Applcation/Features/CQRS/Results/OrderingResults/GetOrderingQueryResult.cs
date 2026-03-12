namespace ItemShop.Order.Applcation.Features.CQRS.Results.OrderingResults
{
    public class GetOrderingQueryResult
    {
         public int OrderingId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}