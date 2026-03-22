using AutoMapper;
using ItemShop.Cargo.Business.Abstract;
using ItemShop.Cargo.DTOs.CargoCompanyDTOs;
using ItemShop.Cargo.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Cargo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _service;
        private readonly IMapper _mapper;

        public CargoCompanyController(ICargoCompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargoCompany()
        {
            var values = await _service.GetAllServiceAsync();

            var mapper = _mapper.Map<List<ResultCargoCompanyDto>>(values);

            return Ok(mapper);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdCargoCompany(int id)
        {
            var value = await _service.GetByIdServiceAsync(id);

            if(value == null)
                return NotFound("Bulunamadı");

            var mapper = _mapper.Map<GetByIdCargoCompanyDto>(value);

            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto dto)
        {
            var mapper = _mapper.Map<CargoCompany>(dto);
            await _service.InsertServiceAsync(mapper);
            return Ok(new { message = "eklendi" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            var value = await _service.GetByIdServiceAsync(dto.CargoCompanyId);

            if (value == null)
            {
                return NotFound("Bulunamadı");
            }

            _mapper.Map(dto, value);
            await _service.UpdateServiceAsync(value);
            return Ok(new { message = "Güncellendi" });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            var value = await _service.GetByIdServiceAsync(id);

            if (value == null)
            {
                return NotFound("Bulunamadı");
            }

            await _service.DeleteServiceAsync(value.CargoCompanyId);
            return Ok(new { message = "Silindi" });

        }
    }
}