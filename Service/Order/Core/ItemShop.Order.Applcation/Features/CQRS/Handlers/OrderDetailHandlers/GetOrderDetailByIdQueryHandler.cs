using ItemShop.Order.Applcation.Features.CQRS.Queries.OrderDetailQueries;
using ItemShop.Order.Applcation.Features.CQRS.Results.OrderDetailResults;
using ItemShop.Order.Applcation.Interfaces;
using ItemShop.Order.Domain.Entities;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>

    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
            {
                return null;
            }

            return new GetOrderDetailByIdQueryResult
            {
                 OrderDetailId =value.OrderDetailId,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductAmount = value.ProductAmount,
                ProductTotalPrice = value.ProductTotalPrice,
                OrderingId = value.OrderingId
            };
        }
    }
}