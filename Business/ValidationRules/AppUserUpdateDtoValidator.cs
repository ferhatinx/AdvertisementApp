using Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AppUserUpdateDtoValidator :AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x=>x.ID).NotEmpty();
            RuleFor(x=>x.Firstname).NotEmpty();
            RuleFor(x=>x.Username).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            RuleFor(x=>x.PhoneNumber).NotEmpty();
            RuleFor(x=>x.GenderId).NotEmpty(); 
            RuleFor(x=>x.Surname).NotEmpty();
        }
    }
}
