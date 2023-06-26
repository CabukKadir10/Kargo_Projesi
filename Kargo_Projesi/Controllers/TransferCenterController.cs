using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

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

        [HttpPost("CreateCenter")]
        public IActionResult CreateCenter(CreateCenterDto createCenterDto)
        {
            var center = _mapper.Map<TransferCenter>(createCenterDto);
            var result = _services.TransferCenterService.Add(center);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetListCenter")]
        public IActionResult GetCenterList()
        {
            var result = _services.TransferCenterService.GetListCenter();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetByIdCenter")]
        public IActionResult GetByIdCenter(int id)
        {
            var result = _services.TransferCenterService.GetByIdCenter(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("UpdateCenter")]
        public IActionResult UpdateCenter(UpdateCenterDto updateCenterDto, int id)
        {
            var getCenter = _services.TransferCenterService.GetByIdCenter(id);
            var center = getCenter.Data;
            center = _mapper.Map<TransferCenter>(updateCenterDto);
            var result = _services.TransferCenterService.Update(center);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("HardDeleteCenter")]
        public IActionResult HardDeleteCenter(int id)
        {
            var center = _services.TransferCenterService.GetByIdCenter(id);
            var result = _services.TransferCenterService.Delete(center.Data);

            if (result.Success)
            {
                return Ok("Başarıyla Silindi");
            }

            return BadRequest();
        }

        [HttpPost("UndBannedCenter")]
        public IActionResult UndoBannedCenter(int id)
        {
            var center = _services.TransferCenterService.GetByIdCenter(id);
            if(center.Data.IsBanned == true)
            {
                center.Data.IsBanned = false;
                return Ok("Ban Kaldırıldı");
            }

            return BadRequest("Banlı Değil");
        }

        [HttpPost("BannedCenter")]
        public IActionResult BannedCenter(int id)
        {
            var center = _services.TransferCenterService.GetByIdCenter(id);
            if(center.Data.IsBanned == false)
            {
                center.Data.IsBanned = true;
                return Ok("Banlandı");
            }

            return BadRequest("Zaten Banlı");
        }
    }
}
