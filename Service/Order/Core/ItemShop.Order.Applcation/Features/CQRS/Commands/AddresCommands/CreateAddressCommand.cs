using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Commands.AddresCommands
{
    public class CreateAddressCommand : IRequest<Unit>
    {
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}