using AutoMapper;
using Entity.Concrete;
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
        public IActionResult CreateStation(Station station)
        {
            var result = _services.StationService.Add(station);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
