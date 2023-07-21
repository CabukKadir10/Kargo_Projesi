using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class MailManager : IMailService
    {
        public void SendMail(string body, string mail)
        {
            var fromAddress = new MailAddress("YourMail@zohomail.eu");
            var toAdress = new MailAddress(mail);

            const string subject = "Nova Kargo | Deneme Maili";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.zoho.eu",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "YourMailPassword")
            })
            {
                using(var message = new MailMessage(fromAddress, toAdress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}
