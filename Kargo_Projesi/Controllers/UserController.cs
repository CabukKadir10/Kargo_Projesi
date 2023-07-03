using AutoMapper;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(UserRegisterDto userRegisterDto)
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

        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }

            return BadRequest();
        }

        [HttpGet("GetByIdUser")]
        public async Task<IActionResult> GetByIdUser(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string  code, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(code);
            if(user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

                if (result.Succeeded)
                    return Ok("Şifre Değiştirme Başarılı");
            }

            return BadRequest();
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
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
