using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Data;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MailController(IServiceManager service)
        {
            _service = service;
        }
       // [Authorize(Roles = "TransferCenter, Agenta, Admin")]
        [HttpPost("SendMail")]
        public IActionResult SendMail([FromBody] Mail mail)
        {
            var body = new StringBuilder();
            body.AppendLine("Gonderen: " + mail.Name);
            body.AppendLine("Konu: " + mail.Subject);
            body.AppendLine("Mesaj: " + mail.Message);

            _service.MailService.SendMail(body.ToString(), mail.Email);

            return Ok("Mail Gönderme Başarılı");
        }
    }
}
