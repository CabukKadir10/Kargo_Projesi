using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FluentValidation
{
    public class AgentaValidator : AbstractValidator<Agenta>
    {
        public AgentaValidator()
        {
            RuleFor(n => n.UnitName).NotEmpty().WithMessage("lütfen isim yerini boş geçmeyiniz");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Lütfen mail şeklinde yazınız");
        }
    }
}
