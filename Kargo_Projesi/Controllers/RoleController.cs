using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
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
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            var role = _mapper.Map<Role>(createRoleDto);
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
                return Ok(result);

            return BadRequest();
        }
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetByIdRole/{id}")]
        public async Task<IActionResult> GetByIdRole(string id)
        {
            var result = await _roleManager.FindByIdAsync(id);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateRole)
        {
            var getRole = await _roleManager.FindByIdAsync(updateRole.Id);

            _mapper.Map(updateRole, getRole);

            var result = await _roleManager.UpdateAsync(getRole);
            if (result.Succeeded)
                return Ok();

            return BadRequest();
        }
    }
}
