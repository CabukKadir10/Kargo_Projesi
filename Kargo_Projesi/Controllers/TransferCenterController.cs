using AutoMapper;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferCenterController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IMapper _mapper;

        public TransferCenterController(IServiceManager services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpPost("CreateCenter")]
        public IActionResult CreateCenter(TransferCenter transferCenter)
        {
            var result = _services.TransferCenterService.Add(transferCenter);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
