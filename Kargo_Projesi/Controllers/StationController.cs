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
    public class StationController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IMapper _mapper;

        public StationController(IServiceManager services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpPost("CreateStation")]
        public IActionResult CreateStation(CreateStationDto createStationDto)
        {
            var station = _mapper.Map<Station>(createStationDto);
            var result = _services.StationService.Add(station);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetByIdStation")]
        public IActionResult GetByIdStation(int id)
        {
            var result = _services.StationService.GetByIdStation(id);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetListStation")]
        public IActionResult GetListStation()
        {
            var result = _services.StationService.GetListStation();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("DeleteStation")]
        public IActionResult DeleteStation(int id)
        {
            var station = _services.StationService.GetByIdStation(id);
            var result = _services.StationService.Delete(station.Data);
            if( result.Success )
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("UpdateStation")]
        public IActionResult UpdateStation(UpdateStationDto updateStationDto, int id)
        {
            var getStation = _services.StationService.GetByIdStation(id);
            var station = getStation.Data;
            station = _mapper.Map<Station>(updateStationDto);
            var result = _services.StationService.Update(station);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
