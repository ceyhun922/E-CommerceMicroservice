using ItemShop.Order.Applcation.Features.CQRS.Commands.OrderDetailCommands;
using ItemShop.Order.Applcation.Interfaces;
using ItemShop.Order.Domain.Entities;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, Unit>
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                  ProductId =request.ProductId,
                  ProductName =request.ProductName,
                  ProductPrice =request.ProductPrice,
                  ProductAmount =request.ProductAmount,
                  ProductTotalPrice =request.ProductTotalPrice,
                  OrderingId =request.OrderingId
            });
            return Unit.Value;
        }
    }
}