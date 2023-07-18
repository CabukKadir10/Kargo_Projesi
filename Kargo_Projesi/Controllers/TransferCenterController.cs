using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Entity.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferCenterController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IMapper _mapper;

        public TransferCenterController(IServiceManager services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("CreateCenter")]
        public IActionResult CreateCenter([FromBody] CreateCenterDto createCenterDto)
        {
            var center = _mapper.Map<TransferCenter>(createCenterDto);
            var result = _services.TransferCenterService.Add(center);

            if (result.Success)
                return Ok(center);

            return BadRequest();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetListCenter")]
        public IActionResult GetCenterList()
        {
            var result = _services.TransferCenterService.GetListCenter();
            if (result.Success)
                return Ok(result.Data);

            return BadRequest();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetByIdCenter/{id}")]
        public IActionResult GetByIdCenter(int id)
        {
            var result = _services.TransferCenterService.GetByIdCenter(u => u.Id == id);
            return Ok(result.Data);
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPut("UpdateCenter/{id}")]
        public IActionResult UpdateCenter([FromBody] UpdateCenterDto updateCenterDto/*, int id*/)
        {
            var getCenter = _services.TransferCenterService.GetByIdCenter(u => u.Id == updateCenterDto.UnitId);

            _mapper.Map(updateCenterDto, getCenter.Data);
            getCenter.Data.ConcurrencyStamp = updateCenterDto.ConurrencyStamp;

            var result = _services.TransferCenterService.Update(getCenter.Data);
            return Ok(updateCenterDto);
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpDelete("HardDeleteCenter/{id}")]
        public IActionResult HardDeleteCenter(int id)
        {
            var result = _services.TransferCenterService.HardDelete(id);
            return Ok("Başarıyla Silindi");
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("CancelDeleteCenter/{id}")]
        public IActionResult CancelDelete(int id)
        {
            _services.TransferCenterService.CancelDelete(id);
            return Ok("Silme İptal edildi");
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("DeleteCenter/{id}")]
        public IActionResult DeletedCenter(int id)
        {
            _services.TransferCenterService.Delete(id);
            return Ok("Seed data başarılı");
        }
    }
}
