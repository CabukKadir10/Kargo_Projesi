using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Entity.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IMapper _mapper;

        public LineController(IServiceManager services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpPost("CreateLine")]
        public IActionResult CreateLine([FromBody]CreateLineDto createLineDto)
        {
            var line = _mapper.Map<Line>(createLineDto);
            var result = _services.LineService.Add(line);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

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

        [HttpPut("UpdateLine")]
        public IActionResult UpdateLine([FromBody]UpdateLineDto updateLineDto)
        {
            //var getLine = _services.LineService.GetByIdLine(id);
            //var line = getLine.Data;
            var line = _mapper.Map<Line>(updateLineDto);
            var result = _services.LineService.Update(line);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

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
