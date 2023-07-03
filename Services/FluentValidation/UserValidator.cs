using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("UserName Boş Olamaz");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Maili Mail Formatında Yazınız");
            RuleFor(a => a.Roles).NotEmpty().WithMessage("rolü belirtiniz lütfen");
            RuleFor(a => a.PasswordHash).MinimumLength(5).MaximumLength(12).WithMessage("şifre en az 5 en çok 12 karakter olması gerekir");
            RuleFor(a => a.PhoneNumber).MaximumLength(12).WithMessage("Telefon en fazla 12 karakter olur");
        }
    }
}
