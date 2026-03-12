using ItemShop.Order.Applcation.Features.CQRS.Results.OrderingResults;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            Id = id;
        }
    }
}