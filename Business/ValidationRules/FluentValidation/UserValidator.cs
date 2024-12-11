using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Validators;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserName).MinimumLength(3);//minimum 2 karakter 
            RuleFor(p=>p.Mail).NotEmpty();// boş geçilemez
            RuleFor(p => p.CompanyId).NotEmpty();
        }
    }
}
