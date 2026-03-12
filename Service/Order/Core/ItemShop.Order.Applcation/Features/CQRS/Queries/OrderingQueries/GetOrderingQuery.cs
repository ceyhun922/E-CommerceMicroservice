using ItemShop.Order.Applcation.Features.CQRS.Results.OrderingResults;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {
        public int OrderingId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}