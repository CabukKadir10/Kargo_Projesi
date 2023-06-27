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
        public IActionResult CreateAgenta(CreateAgentaDto createAgentaDto)
        {
            var agenta = _mapper.Map<Agenta>(createAgentaDto);
            var result = _services.AgentaService.Add(agenta);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetListAgenta")]
        public IActionResult GetListAgenta()
        {
            var result = _services.AgentaService.GetListAgenta();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("GetByIdAgenta")]
        public IActionResult GetByIdAgenta(int id)
        {
            var result = _services.AgentaService.GetByIdAgenta(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("UpdateAgenta")]
        public IActionResult UpdateAgenta(UpdateAgentaDto updateAgentaDto, int id)
        {
            //var getAgenta = _services.AgentaService.GetByIdAgenta(id);
            //var agenta = getAgenta.Data;
            var getAgenta = _services.AgentaService.Get(id);
            var agenta = getAgenta;
            agenta = _mapper.Map<Agenta>(updateAgentaDto);
            var result = _services.AgentaService.Update(agenta);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("DeleteAgenta")]
        public IActionResult DeleteAgenta(int id)
        {
            var agenta = _services.AgentaService.GetByIdAgenta(id);
            var result = _services.AgentaService.Delete(agenta.Data);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
