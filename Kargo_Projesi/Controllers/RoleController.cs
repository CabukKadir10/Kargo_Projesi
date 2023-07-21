using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Entity.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [Authorize(Roles = "TransferCenter, Admin")]
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            var role = _mapper.Map<Role>(createRoleDto);
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
                return Ok(result);

            return BadRequest();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetByIdRole/{id}")]
        public async Task<IActionResult> GetByIdRole(string id)
        {
            var result = await _roleManager.FindByIdAsync(id);
            //if (result is null)
            //    throw new RoleNotFound(result.Id);

            return Ok(result);
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateRole)
        {
            var getRole = await _roleManager.FindByIdAsync(updateRole.Id);
            _mapper.Map(updateRole, getRole);
            if (getRole is null)
                throw new RoleNotFound(getRole.Id);
            var result = await _roleManager.UpdateAsync(getRole);

            return Ok(result);
        }
    }
}
