using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FluentValidation
{
    public class StationValidator : AbstractValidator<Station>
    {
        public StationValidator()
        {
            RuleFor(a => a.UnitId).NotEmpty().WithMessage("her durak bir unite bağlıdır boş bırakmayınız");
            RuleFor(a => a.OrderNumber).GreaterThanOrEqualTo(10).WithMessage("her hatta en fazla 10 durak olur");
        }
    }
}
