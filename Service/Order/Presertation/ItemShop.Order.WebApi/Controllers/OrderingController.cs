

using ItemShop.Order.Applcation.Features.CQRS.Commands.OrderingCommands;
using ItemShop.Order.Applcation.Features.CQRS.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Order.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ordering-list")]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByOrdering(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));

            if (value == null)
            {
                return NotFound("Bulunamadı");

            }
            return Ok(value);
        }

        [HttpPost("create-ordering")]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Eklendi");
        }

        [HttpPut("ordering-update")]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncellendi");
        }

        [HttpDelete("remove-ordering")]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));

             if (value == null)
            {
                return NotFound("Bulunamadı");

            }

            await _mediator.Send(new DeleteOrderingCommand(id));

            return Ok("Silindi");
        }
    }
} 