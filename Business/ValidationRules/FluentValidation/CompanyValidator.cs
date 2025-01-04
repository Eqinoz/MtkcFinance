using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator:AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(p => p.CompanyName).MinimumLength(3).WithMessage("Şirket İsmi Minimum 3 Karakter Olmalı");
        }
    }
}
