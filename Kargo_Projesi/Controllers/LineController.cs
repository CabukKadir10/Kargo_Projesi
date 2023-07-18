using AutoMapper;
using Data.Abstract;
using Entity.Concrete;
using Entity.Dto;
using Entity.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public LineController(IServiceManager services, IMapper mapper, IStationDal station, UserManager<User> manager)
        {
            _services = services;
            _mapper = mapper;
            _station = station;
            _userManager = manager;
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("CreateLine")]
        public IActionResult CreateLine([FromBody]CreateLineDto createLineDto)
        {
            var line = _mapper.Map<Line>(createLineDto);
            var result = _services.LineService.Add(line);

            if (result.Success)
                return Ok(line);

            return BadRequest();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetListLine")]
        public IActionResult GetListLine()
        {
            var result = _services.LineService.GetListLine();
            if (result.Success)
                return Ok(result.Data);

            return BadRequest();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetByIdLine/{id}")]
        public IActionResult GetByIdLine(int id)
        {
            var result = _services.LineService.GetByIdLine(id);
            return Ok(result.Data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateLine")]
        public IActionResult UpdateLine([FromBody]UpdateLineDto updateLineDto)
        {
            var line = _mapper.Map<Line>(updateLineDto);
            var result = _services.LineService.Update(line);
            return Ok(line);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteLine/{id}")]
        public IActionResult DeleteLine(int id)
        {
            var result = _services.LineService.Delete(id);
            return Ok(result);
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("LineIdToStation/{lineId}")]
        public IActionResult GetListStation(int lineId)
        {
            var result = _services.StationService.GetListStation2(d => d.LineId == lineId);
            if (result.Success)
                return Ok(result.Data);
            

            return BadRequest();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetListUserLine")]
        public async Task<IActionResult> GetListUserLine()
        {
            var userId = User.Identity.Name;
            var getUser = await _userManager.FindByNameAsync(userId);
            var unitId = getUser.UnitId;

            var result = _services.LineService.GetListByIdUserLine(unitId);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
