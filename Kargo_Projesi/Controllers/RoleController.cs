﻿using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            var role = _mapper.Map<Role>(createRoleDto);
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
                return Ok(result);

            return BadRequest();
        }

        [HttpGet("GetByIdRole")]
        public async Task<IActionResult> GetByIdRole(string id)
        {
            var result = await _roleManager.FindByIdAsync(id);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(CreateRoleDto createRoleDto)
        {
            var role = _mapper.Map<Role>(createRoleDto);
            var getRole = await _roleManager.FindByNameAsync(createRoleDto.Name);
            getRole = role;
            var result = await _roleManager.UpdateAsync(getRole);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest();
        }
    }
}