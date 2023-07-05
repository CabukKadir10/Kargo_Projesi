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
        public IActionResult CreateAgenta([FromBody] CreateAgentaDto createAgentaDto)
        {
            if (createAgentaDto == null)
                return BadRequest();

            var agenta = _mapper.Map<Agenta>(createAgentaDto);
            _services.AgentaService.Add(agenta);

            return Ok(agenta);
        }

        [HttpGet("GetListAgenta")]
        public IActionResult GetListAgenta()
        {
            var result = _services.AgentaService.GetListAgenta();
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetByIdAgenta/{id}")]
        public IActionResult GetByIdAgenta(int id)
        {
            var result = _services.AgentaService.GetByIdAgenta(id);

            if (result is null)
                throw new AgentaNotFound(id);

            return Ok(result);
        }

        [HttpPut("UpdateAgenta")]
        public IActionResult UpdateAgenta([FromBody] UpdateAgentaDto updateAgentaDto)
        {
            //var getAgenta = _services.AgentaService.GetByIdAgenta(id);
            //var agenta = getAgenta.Data;
            var getAgenta = _services.AgentaService.Get(updateAgentaDto.UnitId);
            if(getAgenta is null)
                throw new AgentaNotFound(updateAgentaDto.UnitId);

            var agenta = getAgenta;
            agenta = _mapper.Map<Agenta>(updateAgentaDto);
            _services.AgentaService.Update(agenta);

            return Ok(agenta);
        }

        [HttpDelete("DeleteAgenta/{id}")]
        public IActionResult DeleteAgenta(int id)
        {
            var agenta = _services.AgentaService.GetByIdAgenta(id);
            if (agenta is null)
                throw new AgentaNotFound(id);

            _services.AgentaService.Delete(agenta);
            return Ok();
        }
    }
}
