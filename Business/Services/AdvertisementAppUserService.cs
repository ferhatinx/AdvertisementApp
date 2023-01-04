using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Common;
using DataAccess.UnitOfWork;
using Dtos;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;

        public AdvertisementAppUserService(IUow uow, IMapper mapper, IValidator<AdvertisementAppUserCreateDto> createDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }
        public async Task<IResponseT<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid) 
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);
                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _uow.SaveChangesAsync();
                    return new ResponseT<AdvertisementAppUserCreateDto>(ResponseType.Success,dto);
                }
                List<CustomValidationError> customErrors = new List<CustomValidationError> { new CustomValidationError { ErrorMessage = "Bir daha başvuru yapılamaz", PropertyName = "" } };

            }
            return new ResponseT<AdvertisementAppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());
        
        }
    }
}

