using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
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
       // [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
        {
            var getUser = _mapper.Map<User>(userRegisterDto);

            if(!(_userManager.Users.Any(u => u.PhoneNumber == userRegisterDto.PhoneNumber)))
            {
                var result = await _userManager.CreateAsync(getUser, userRegisterDto.PasswordHash);
                if (result.Succeeded)
                {
                    var addRole = await _userManager.AddToRoleAsync(getUser, userRegisterDto.Roles);
                    return Ok(result);
                }
                else
                    return BadRequest(error: "hata");
            }

            return BadRequest(error: "kullanıcı oluşturulamadı.");
        }
       // [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginDto userLoginDto)
        {
            var role = _mapper.Map<Role>(userLoginDto);

            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
                if (result.Succeeded && user.Roles.Equals(role.Name))
                {
                    var token = _serviceManager.AuthService.CreateAccessToken(user, role);
                    return Ok(token);
                }
            }

            return BadRequest();
        }
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("GetByIdUser/{id}")]
        public async Task<IActionResult> GetByIdUser(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePassword)
        {
            var user = await _userManager.FindByIdAsync(changePassword.Code);
            if(user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.newPassword);

                if (result.Succeeded)
                    return Ok("Şifre Değiştirme Başarılı");
            }

            return BadRequest();
        }
        [Authorize(Roles = "User, Editor, Admin")]
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByEmailAsync(updateUserDto.Email);
            if(user != null)
            {
                var getUser = _mapper.Map<User>(updateUserDto);
                user = getUser;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return Ok();
            }

            return BadRequest();
        }
    }
}
