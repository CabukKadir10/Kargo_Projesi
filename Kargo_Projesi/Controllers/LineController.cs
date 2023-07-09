using AutoMapper;
using Data.Abstract;
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
    public class LineController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IMapper _mapper;
        private readonly IStationDal _station;

        public LineController(IServiceManager services, IMapper mapper, IStationDal station)
        {
            _services = services;
            _mapper = mapper;
            _station = station;
        }
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("CreateLine")]
        public IActionResult CreateLine([FromBody]CreateLineDto createLineDto)
        {
            var line = _mapper.Map<Line>(createLineDto);
            //var station = _services.StationService.GetListStation2(a => a.UnitId == createLineDto);
           // var test = _services.StationService.Add();
            var result = _services.LineService.Add(line);

            if(createLineDto.CenterId != null)
            {
                var lastStation = new Station
                {
                    StationName = $"{line.LineName} durak",
                    OrderNumber = createLineDto.Stations.Length + 1,
                    LineId = line.LineId,
                    IsActive = true,
                    UnitId = createLineDto.CenterId
                };
                _station.Create(lastStation);
            }

            if (result.Success)
                return Ok(line);

            return BadRequest();
        }
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetListLine")]
        public IActionResult GetListLine()
        {
            var result = _services.LineService.GetListLine();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
       // [Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetByIdLine/{id}")]
        public IActionResult GetByIdLine(int id)
        {
            var result = _services.LineService.GetByIdLine(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpPut("UpdateLine")]
        public IActionResult UpdateLine([FromBody]UpdateLineDto updateLineDto)
        {
            //var getLine = _services.LineService.GetByIdLine(id);
            //var line = getLine.Data;
            var line = _mapper.Map<Line>(updateLineDto);
            var result = _services.LineService.Update(line);
            if(result.Success)
            {
                return Ok(line);
            }

            return BadRequest();
        }
       // [Authorize(Roles = "User, Editor, Admin")]
        [HttpDelete("DeleteLine/{id}")]
        public IActionResult DeleteLine(int id)
        {
            var line = _services.LineService.GetByIdLine(id);
            var result = _services.LineService.Delete(line.Data);
            if( result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        //[Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("LineIdToStation/{lineId}")]
        public IActionResult GetStationList(int lineId)
        {
            var result = _services.StationService.GetListStation2(d => d.LineId == lineId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
