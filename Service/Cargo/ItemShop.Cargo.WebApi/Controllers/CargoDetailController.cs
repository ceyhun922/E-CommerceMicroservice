using AutoMapper;
using ItemShop.Cargo.Business.Abstract;
using ItemShop.Cargo.DTOs.CargoDetailDTOs;
using ItemShop.Cargo.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.Cargo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _service;
        private readonly IMapper _mapper;

        public CargoDetailController(ICargoDetailService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

         [HttpGet]
        public async Task<IActionResult> GetAllCargoDetail()
        {
            var values = await _service.GetAllServiceAsync();

            var mapper = _mapper.Map<List<ResultCargoDetailDto>>(values);

            return Ok(mapper);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdCargoDetail(int id)
        {
            var value = await _service.GetByIdServiceAsync(id);

            if(value == null)
                return NotFound("Bulunamadı");

            var mapper = _mapper.Map<GetByIdCargoDetailDto>(value);

            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto dto)
        {
            var mapper = _mapper.Map<CargoDetail>(dto);
            await _service.InsertServiceAsync(mapper);
            return Ok(new { message = "eklendi" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            var value = await _service.GetByIdServiceAsync(dto.CargoDetailId);

            if (value == null)
            {
                return NotFound("Bulunamadı");
            }

            _mapper.Map(dto, value);
            await _service.UpdateServiceAsync(value);
            return Ok(new { message = "Güncellendi" });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            var value = await _service.GetByIdServiceAsync(id);

            if (value == null)
            {
                return NotFound("Bulunamadı");
            }

            await _service.DeleteServiceAsync(value.CargoDetailId);
            return Ok(new { message = "Silindi" });

        }
    }
}