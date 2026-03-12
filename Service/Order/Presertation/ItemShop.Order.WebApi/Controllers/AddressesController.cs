using ItemShop.Order.Applcation.Features.CQRS.Commands.AddresCommands;
using ItemShop.Order.Applcation.Features.CQRS.Queries.AdressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Order.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("addresses-list")]
        public async Task<IActionResult> AdressesList()
        {
            var values = await _mediator.Send(new GetAddressQuery());
            return Ok(values);
        }

        [HttpPost("create-address")]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Eklendl");
        }
        [HttpGet("get-adress/{id}")]
        public async Task<IActionResult> GetByIdAddress(int id)
        {
            var value = await _mediator.Send(new GetAddressByIdQuery(id));

            if (value == null) return NotFound("Bulunamadı");

            return Ok(value);
        }

        [HttpPut("update-address")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _mediator.Send(command);

            return Ok("Güncellendi");
        }

        [HttpDelete("delete-adress/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var value = await _mediator.Send(new GetAddressByIdQuery(id));
            if (value == null) return NotFound("Bulunamadı");

            await _mediator.Send(new DeleteAddressCommand(value.AddressId));
            return Ok("Silindi");
        }
    }
}