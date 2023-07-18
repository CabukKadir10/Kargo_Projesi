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
    public class StationController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IMapper _mapper;

        public StationController(IServiceManager services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("CreateStation")]
        public IActionResult CreateStation([FromBody] CreateStationDto createStationDto)
        {
            var station = _mapper.Map<Station>(createStationDto);
            _services.StationService.Add(station);
            return Ok(station);
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetByIdStation/{id}")]
        public IActionResult GetByIdStation(int id)
        {
            var result = _services.StationService.GetByIdStation(id);
            return Ok(result);
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetListStation")]
        public IActionResult GetListStation()
        {
            var result = _services.StationService.GetListStation();
            if (result.Success)
                return Ok(result.Data);

            return BadRequest();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpDelete("DeleteStation/{id}")]
        public IActionResult DeleteStation(int id)
        {
            var result = _services.StationService.Delete(id);
            return Ok();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPut("UpdateStation")]
        public IActionResult UpdateStation([FromBody] UpdateStationDto updateStationDto)
        {
            var station = _mapper.Map<Station>(updateStationDto);
            var result = _services.StationService.Update(station);
            return Ok(station);
        }
    }
}
