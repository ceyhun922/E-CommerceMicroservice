

using ItemShop.Order.Applcation.Features.CQRS.Commands.AddresCommands;
using ItemShop.Order.Applcation.Interfaces;
using ItemShop.Order.Domain.Entities;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.AddressId);
            value.City =request.City;
            value.Detail =request.Detail;
            value.District =request.District;
            value.UserId =request.UserId;

            await _repository.UpdateAsync(value);
        }
    }
}