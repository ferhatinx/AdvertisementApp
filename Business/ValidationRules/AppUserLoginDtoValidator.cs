using Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>

    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Boş olamaz");
        }
    }
}
