using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Common;
using DataAccess.UnitOfWork;
using Dtos;
using Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AppUserService : Service<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser> , IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<AppUserCreateDto> _createdtovalidator;


        public AppUserService(IMapper mapper,IValidator<AppUserCreateDto> createdtovalidator, IValidator<AppUserUpdateDto> updatedtovalidator,IUow uow) : 
            base(mapper,createdtovalidator,updatedtovalidator,uow)
        {
            _mapper = mapper;
            _uow = uow;
            _createdtovalidator = createdtovalidator;
        } 
        public async Task<IResponseT<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleid)
        {
            var result = _createdtovalidator.Validate(dto);
            if (result.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
              

                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleid
                });
                await _uow.SaveChangesAsync();
                return new ResponseT<AppUserCreateDto>(ResponseType.Success,dto);

            }
            return new ResponseT<AppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }
    }
}
