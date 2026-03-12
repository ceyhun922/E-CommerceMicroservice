using ItemShop.Order.Applcation.Features.CQRS.Commands;
using ItemShop.Order.Applcation.Features.CQRS.Commands.AddresCommands;
using ItemShop.Order.Applcation.Interfaces;
using ItemShop.Order.Domain.Entities;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Handlers.AddressHandlers
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Unit>
    {
        private readonly IRepository<Address> _repository;

        public DeleteAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
           var value =await _repository.GetByIdAsync(request.Id);

           await _repository.DeleteAsync(value);
           return Unit.Value;
        }
    }
}