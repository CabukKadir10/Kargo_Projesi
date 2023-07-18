    using AutoMapper;
using Core.Aspects.AutoFac.Validation;
using Entity.Concrete;
using Entity.Dto;
using Entity.Exceptions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.FluentValidation;

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

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("CreateAgenta")]
        public IActionResult CreateAgenta([FromBody] CreateAgentaDto createAgentaDto)
        {
            var agenta = _mapper.Map<Agenta>(createAgentaDto);
            _services.AgentaService.Add(agenta);
            return Ok(agenta);
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetListAgenta")]
        public IActionResult GetListAgenta()
        {
            var result = _services.AgentaService.GetListAgenta();
            return Ok(result);
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetByIdAgenta/{id}")]
        public IActionResult GetByIdAgenta(int id)
        {
            var result = _services.AgentaService.Get(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateAgenta")]
        public IActionResult UpdateAgenta([FromBody] UpdateAgentaDto updateAgentaDto/*, int id*/)
        {
            var getAgenta = _services.AgentaService.GetByIdAgenta(u => u.Id == updateAgentaDto.UnitId);
            _mapper.Map(updateAgentaDto, getAgenta);
            getAgenta.ConcurrencyStamp = updateAgentaDto.ConurrencyStamp;

            _services.AgentaService.Update(getAgenta);
            return Ok(getAgenta);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteAgenta/{id}")]
        public IActionResult DeleteAgenta(int id)
        {
            _services.AgentaService.HardDelete(id);
            return Ok();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("CancelDeleteAgenta/{id}")]
        public IActionResult CancelDelete(int id)
        {
            _services.AgentaService.CancelDelete(id);
            return Ok("silme İptal Edildi");
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("DeleteAgenta/{id}")]
        public IActionResult DeletedAgenta(int id)
        {
            _services.AgentaService.Delete(id);
            return Ok("Seed Data Başarılı");
        }
    }
}
