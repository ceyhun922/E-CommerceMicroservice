
using ItemShop.Order.Applcation.Features.CQRS.Commands.OrderingCommands;
using ItemShop.Order.Applcation.Interfaces;
using ItemShop.Order.Domain.Entities;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
             var value = await _repository.GetByIdAsync(request.OrderingId);
                value.UserId =request.UserId;
                value.TotalPrice =request.TotalPrice;
                value.OrderDate =request.OrderDate;

            await _repository.UpdateAsync(value);
        }
    }
}