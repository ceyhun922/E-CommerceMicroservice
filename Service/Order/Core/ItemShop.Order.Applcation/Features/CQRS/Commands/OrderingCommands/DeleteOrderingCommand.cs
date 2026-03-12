using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Commands.OrderingCommands
{
    public class DeleteOrderingCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteOrderingCommand(int id)
        {
            Id = id;
        }
    }
}