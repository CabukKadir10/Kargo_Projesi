using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
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
       // [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("CreateCenter")]
        public IActionResult CreateCenter([FromBody] CreateCenterDto createCenterDto)
        {
            var center = _mapper.Map<TransferCenter>(createCenterDto);
            var result = _services.TransferCenterService.Add(center);

            if (result.Success)
            {
                return Ok(center);
            }

            return BadRequest();
        }
       // [Authorize(Roles = "User, Editor, Admin")]
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
       // [Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetByIdCenter/{id}")]
        public IActionResult GetByIdCenter(int id)
        {
            var result = _services.TransferCenterService.GetByIdCenter(u => u.Id == id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpPut("UpdateCenter/{id}")]
        public IActionResult UpdateCenter([FromBody] UpdateCenterDto updateCenterDto, int id)
        {
            var getCenter = _services.TransferCenterService.GetByIdCenter(u => u.Id == id);
            _mapper.Map(updateCenterDto, getCenter.Data);
            getCenter.Data.ConcurrencyStamp = updateCenterDto.ConurrencyStamp;
            var result = _services.TransferCenterService.Update(getCenter.Data);

            if (result.Success)
            {
                return Ok(updateCenterDto);
            }

            return BadRequest();
        }
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpDelete("HardDeleteCenter/{id}")]
        public IActionResult HardDeleteCenter(int id)
        {
            var center = _services.TransferCenterService.GetByIdCenter(u => u.Id == id);
            var result = _services.TransferCenterService.Delete(center.Data);

            if (result.Success)
            {
                return Ok("Başarıyla Silindi");
            }

            return BadRequest();
        }
       // [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("UndIsDeletedCenter/{id}")]
        public IActionResult UndoIsDeletedCenter(int id)
        {
            var center = _services.TransferCenterService.GetByIdCenter(u => u.Id == id);
            if(center.Data.IsDeleted == true)
            {
                center.Data.IsDeleted = false;
                _services.TransferCenterService.Update(center.Data);
                return Ok("Ban Kaldırıldı");
            }

            return BadRequest("Banlı Değil");
        }
       // [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("IsDeletedCenter/{id}")]
        public IActionResult IsDeletedCenter(int id)
        {
            var center = _services.TransferCenterService.GetByIdCenter(u => u.Id == id);
            if(center.Data.IsDeleted == false)
            {
                center.Data.IsDeleted = true;
                _services.TransferCenterService.Update(center.Data);
                return Ok("Banlandı");
            }

            return BadRequest("Zaten Banlı");
        }
    }
}
