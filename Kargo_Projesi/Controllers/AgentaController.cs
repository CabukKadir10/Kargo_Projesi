﻿    using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Entity.Exceptions;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles ="User, Editor, Admin")]
        [HttpPost("CreateAgenta")]
        public IActionResult CreateAgenta([FromBody] CreateAgentaDto createAgentaDto)
        {
            if (createAgentaDto == null)
                return BadRequest();

            var agenta = _mapper.Map<Agenta>(createAgentaDto);
            _services.AgentaService.Add(agenta);

            return Ok(agenta);
        }
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetListAgenta")]
        public IActionResult GetListAgenta()
        {
            var result = _services.AgentaService.GetListAgenta();
            if (result is null)
                return NotFound();

            return Ok(result);
        }
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetByIdAgenta/{id}")]
        public IActionResult GetByIdAgenta(int id)
        {
            var result = _services.AgentaService.Get(id);

            if (result is null)
                throw new AgentaNotFound(id);

            return Ok(result);
        }
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPut("UpdateAgenta/{id}")]
        public IActionResult UpdateAgenta([FromBody] UpdateAgentaDto updateAgentaDto, int id)
        {
            var getAgenta = _services.AgentaService.GetByIdAgenta(u => u.Id ==id);
            _mapper.Map(updateAgentaDto, getAgenta);
            getAgenta.ConcurrencyStamp = updateAgentaDto.ConurrencyStamp;
            _services.AgentaService.Update(getAgenta);

            return Ok(getAgenta);
        }
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpDelete("DeleteAgenta/{id}")]
        public IActionResult DeleteAgenta(int id)
        {
            var agenta = _services.AgentaService.Get(id);
            if (agenta is null)
                throw new AgentaNotFound(id);

            _services.AgentaService.Delete(agenta);
            return Ok();
        }
    }
}
