using FluentValidation;
using System;
using UI.Models;

namespace UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Password alanı boş olamaz");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("En az 3 karakter olmalıdır");
            RuleFor(x=>x.Password).Equal(x=>x.PasswordConfirm).WithMessage("Password eşleşmiyor");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad alanı boş olamaz");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soyad Alanı boş olamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("En az 3 karakter olmalıdır");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet Seçiniz");
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Firstname, x.Username)).WithMessage("kullanıcı adı,adınız olmamalı")
            .When(x => x.Username != null && x.Firstname != null);

        }
        private bool CanNotFirstname(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
