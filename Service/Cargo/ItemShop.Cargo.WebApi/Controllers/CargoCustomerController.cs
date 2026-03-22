using AutoMapper;
using ItemShop.Cargo.Business.Abstract;
using ItemShop.Cargo.DTOs.CargoCustomerDTOs;
using ItemShop.Cargo.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Cargo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService  _service;
        private readonly IMapper _mapper;

        public CargoCustomerController(ICargoCustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

         [HttpGet]
        public async Task<IActionResult> GetAllCargoCustomer()
        {
            var values = await _service.GetAllServiceAsync();

            var mapper = _mapper.Map<List<ResultCargoCustomerDto>>(values);

            return Ok(mapper);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdCargoCustomer(int id)
        {
            var value = await _service.GetByIdServiceAsync(id);

            if(value == null)
                return NotFound("Bulunamadı");

            var mapper = _mapper.Map<GetByIdCargoCustomerDto>(value);

            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto dto)
        {
            var mapper = _mapper.Map<CargoCustomer>(dto);
            await _service.InsertServiceAsync(mapper);
            return Ok(new { message = "eklendi" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto dto)
        {
            var value = await _service.GetByIdServiceAsync(dto.CargoCustomerId);

            if (value == null)
            {
                return NotFound("Bulunamadı");
            }

            _mapper.Map(dto, value);
            await _service.UpdateServiceAsync(value);
            return Ok(new { message = "Güncellendi" });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            var value = await _service.GetByIdServiceAsync(id);

            if (value == null)
            {
                return NotFound("Bulunamadı");
            }

            await _service.DeleteServiceAsync(value.CargoCustomerId);
            return Ok(new { message = "Silindi" });

        }
    }   
}