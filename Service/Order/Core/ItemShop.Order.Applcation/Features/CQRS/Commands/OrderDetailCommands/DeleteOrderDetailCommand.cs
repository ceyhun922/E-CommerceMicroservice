using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand : IRequest<Unit>
    {
       public int Id { get; set; }

        public DeleteOrderDetailCommand(int id)
        {
            Id = id;
        }
    }
}