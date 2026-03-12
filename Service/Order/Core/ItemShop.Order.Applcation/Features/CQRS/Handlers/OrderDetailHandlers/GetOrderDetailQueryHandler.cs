using ItemShop.Order.Applcation.Features.CQRS.Queries.OrderDetailQueries;
using ItemShop.Order.Applcation.Features.CQRS.Results.OrderDetailResults;
using ItemShop.Order.Applcation.Interfaces;
using ItemShop.Order.Domain.Entities;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailId = x.OrderingId,
                ProductId =x.ProductId,
                 ProductName =x.ProductName,
                 ProductPrice =x.ProductPrice,
                ProductAmount =x.ProductAmount,
                ProductTotalPrice =x.ProductTotalPrice,
                OrderingId =x.OrderingId
            }).ToList();
        }
    }
}