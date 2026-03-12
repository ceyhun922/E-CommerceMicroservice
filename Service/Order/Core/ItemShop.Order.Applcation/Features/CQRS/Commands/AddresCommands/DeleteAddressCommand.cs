using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Commands.AddresCommands
{
    public class DeleteAddressCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteAddressCommand(int id)
        {
            Id = id;
        }
    }
}