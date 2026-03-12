using ItemShop.Order.Applcation.Features.CQRS.Results.OrderDetailResults;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery : IRequest<GetOrderDetailByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}