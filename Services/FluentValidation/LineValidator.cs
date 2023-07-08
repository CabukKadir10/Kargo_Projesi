using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FluentValidation
{
    public class LineValidator : AbstractValidator<Line>
    {
        public LineValidator()
        {
            RuleFor(n => n.LineName).NotEmpty().WithMessage("isim alanı boş olamaz").MaximumLength(20);
            RuleFor(O => O.LineType).NotEmpty().WithMessage("line tipini belirtiniz");
        }
    }
}
