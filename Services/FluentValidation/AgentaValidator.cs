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
            RuleFor(a => a.Gsm).MinimumLength(3).MaximumLength(11).Must(BeNumeric).WithMessage("Gsm en az 3 en fazla 11 karakter olmalı");
            RuleFor(a => a.PhoneNumber).MinimumLength(3).MaximumLength(11).Must(BeNumeric).WithMessage("gsm rakamlardan olmalı").NotEmpty().WithMessage("telefon numarası en az 3 en fazla 11 karakter olmalı");
            RuleFor(a => a.CenterId).NotEmpty().WithMessage("center ıd belirleyiniz");
        }

        private bool BeNumeric(string value)
        {
            return int.TryParse(value, out _);
        }
    }
}
