using AutoMapper;
using ItemShop.Cargo.Business.Abstract;
using ItemShop.Cargo.DTOs.CargoOperationDTOs;
using ItemShop.Cargo.DTOs.CargoOperationDTOs;
using ItemShop.Cargo.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Cargo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _service;
        private readonly IMapper _mapper;

        public CargoOperationController(ICargoOperationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

         [HttpGet]
        public async Task<IActionResult> GetAllCargoOperation()
        {
            var values = await _service.GetAllServiceAsync();

            var mapper = _mapper.Map<List<ResultCargoOperationDto>>(values);

            return Ok(mapper);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdCargoOperation(int id)
        {
            var value = await _service.GetByIdServiceAsync(id);

            if(value == null)
                return NotFound("Bulunamadı");

            var mapper = _mapper.Map<GetByIdCargoOperationDto>(value);

            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto dto)
        {
            var mapper = _mapper.Map<CargoOperation>(dto);
            await _service.InsertServiceAsync(mapper);
            return Ok(new { message = "eklendi" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            var value = await _service.GetByIdServiceAsync(dto.CargoOperationId);

            if (value == null)
            {
                return NotFound("Bulunamadı");
            }

            _mapper.Map(dto, value);
            await _service.UpdateServiceAsync(value);
            return Ok(new { message = "Güncellendi" });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoOperation(int id)
        {
            var value = await _service.GetByIdServiceAsync(id);

            if (value == null)
            {
                return NotFound("Bulunamadı");
            }

            await _service.DeleteServiceAsync(value.CargoOperationId);
            return Ok(new { message = "Silindi" });

        }
    }
}