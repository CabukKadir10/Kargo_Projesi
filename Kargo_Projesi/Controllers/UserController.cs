//using AutoMapper;
//using Entity.Concrete;
//using Entity.Dto;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly UserManager<User> _userManager;
//        private readonly RoleManager<Role> _roleManager;
//        private readonly IMapper _mapper;

//        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
//        {
//            _userManager = userManager;
//            _roleManager = roleManager;
//            _mapper = mapper;
//        }

//        [HttpPost("CreateUser")]
//        public async Task<IActionResult> CreateUser(UserRegisterDto userRegisterDto)
//        {
//            var user = _mapper.Map<User>(userRegisterDto);

//            //buraya sonradan telefon kontrol sistemi ekle

//            var result = await _userManager.CreateAsync(user, userRegisterDto.PasswordHash);
//            if(result.Succeeded)
//            {
//                await _userManager.AddToRoleAsync(user, userRegisterDto.Roles);
//                return Ok(result);
//            }

//            return BadRequest();
//        }
//    }
//}
