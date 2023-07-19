using AutoMapper;
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
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IMapper mapper, IServiceManager serviceManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _serviceManager = serviceManager;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
        {
            var getUser = _mapper.Map<User>(userRegisterDto);
            await _serviceManager.UserService.RegisterUser(getUser);
            return Ok(getUser);
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginDto userLoginDto)
        {
          // var role = _mapper.Map<Role>(userLoginDto);

            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            var role = _serviceManager.RoleService.GetRole(user.Roles);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
                if (result.Succeeded && user.Roles.Equals(role.Data.Name))
                {
                    var token = _serviceManager.AuthService.CreateAccessToken(user, role.Data);
                    return Ok(token);
                }
            }

            return BadRequest();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpGet("GetByIdUser/{id}")]
        public async Task<IActionResult> GetByIdUser(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            if (result is null)
                throw new UserNotFound(result.Id);

            return Ok(result);
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePassword)
        {
            var user = await _userManager.FindByIdAsync(changePassword.Code);
            if(user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.newPassword);
                var updateUser = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return Ok("Şifre Değiştirme Başarılı");
            }

            return BadRequest();
        }

        [Authorize(Roles = "Agenta, TransferCenter, Admin")]
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var getUser = await _userManager.FindByIdAsync(updateUserDto.Id);
            _mapper.Map(getUser, updateUserDto);
            var result = await _userManager.UpdateAsync(getUser);
            if (result.Succeeded)
                return Ok(getUser);

            return BadRequest();
        }
    }
}
