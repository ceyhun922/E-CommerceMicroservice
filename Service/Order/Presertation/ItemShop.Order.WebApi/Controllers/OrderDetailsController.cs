using ItemShop.Order.Applcation.Features.CQRS.Commands.OrderDetailCommands;
using ItemShop.Order.Applcation.Features.CQRS.Queries.OrderDetailQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Order.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("orderdetail-list")]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _mediator.Send(new GetOrderDetailQuery());
            return Ok(values);
        }
        [HttpPost("create-orderdetail")]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok("Eklendi");
        }

        [HttpGet("get-orderdetail/{id}")]
        public async Task<IActionResult> GetByIdOrderDetail(int id)
        {
            var value = await _mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPut("update-orderdetail")]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _mediator.Send(command);

            return Ok("Güncellendi");

        }

        [HttpDelete("delete-orderdetail/{id}")]

        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _mediator.Send(new DeleteOrderDetailCommand(id));
            return Ok("Silindi");
        }
    }
}