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
    public class StationController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IMapper _mapper;

        public StationController(IServiceManager services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("CreateStation")]
        public IActionResult CreateStation([FromBody] CreateStationDto createStationDto)
        {
            var station = _mapper.Map<Station>(createStationDto);
            _services.StationService.Add(station);
            return Ok(station);
        }
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetByIdStation/{id}")]
        public IActionResult GetByIdStation(int id)
        {
            var result = _services.StationService.GetByIdStation(id);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        //[Authorize(Roles = "User, Editor, Admin")]
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
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpDelete("DeleteStation/{id}")]
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
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpPut("UpdateStation")]
        public IActionResult UpdateStation([FromBody] UpdateStationDto updateStationDto)
        {
            //var getStation = _services.StationService.GetByIdStation(id);
            //var station = getStation.Data;
            var station = _mapper.Map<Station>(updateStationDto);
            var result = _services.StationService.Update(station);

            if (result.Success)
            {
                return Ok(station);
            }

            return BadRequest();
        }
    }
}
