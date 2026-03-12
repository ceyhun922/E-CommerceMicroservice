using ItemShop.Order.Applcation.Features.CQRS.Commands.OrderDetailCommands;
using ItemShop.Order.Applcation.Interfaces;
using ItemShop.Order.Domain.Entities;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
           var value =await _repository.GetByIdAsync(request.OrderDetailId);

            value.ProductId =request.ProductId;
            value.ProductName =request.ProductName;
            value.ProductPrice =request.ProductPrice;
            value.ProductAmount =request.ProductAmount;
            value.ProductTotalPrice =request.ProductTotalPrice;
            value.OrderingId =request.OrderingId;

            await _repository.UpdateAsync(value);
        }
    }
}