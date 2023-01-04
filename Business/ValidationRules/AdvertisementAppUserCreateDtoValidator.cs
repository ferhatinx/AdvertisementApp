﻿using Common.Enums;
using Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(x=>x.AdvertisementId).NotEmpty();
            RuleFor(x=>x.AdvertisementAppUserStatusId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x=>x.CvPath).NotEmpty().WithMessage("Bir cv dosyası seçiniz");
            RuleFor(x=>x.WorkExperience).NotEmpty();
            RuleFor(x=>x.EndDate).NotEmpty().When(x=>x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli).WithMessage("Tecil tarihi boş olamaz");
        }
    }
}
