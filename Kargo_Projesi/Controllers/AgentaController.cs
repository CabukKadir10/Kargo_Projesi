using AutoMapper;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentaController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IMapper _mapper;

        public AgentaController(IServiceManager services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpPost("CreateAgenta")]
        public IActionResult CreateAgenta(Agenta agenta)
        {
            var result = _services.AgentaService.Add(agenta);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
