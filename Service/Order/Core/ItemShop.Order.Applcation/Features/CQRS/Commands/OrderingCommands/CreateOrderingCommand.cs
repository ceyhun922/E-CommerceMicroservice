using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Commands.OrderingCommands
{
    public class CreateOrderingCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}