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
        private readonly IValidator<AppUserLoginDto> _logindtovalidator;


        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createdtovalidator, IValidator<AppUserUpdateDto> updatedtovalidator, IUow uow, IValidator<AppUserLoginDto> logindtovalidator = null) :
            base(mapper, createdtovalidator, updatedtovalidator, uow)
        {
            _mapper = mapper;
            _uow = uow;
            _createdtovalidator = createdtovalidator;
            _logindtovalidator = logindtovalidator;
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
        public async Task<IResponseT<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationresult = _logindtovalidator.Validate(dto);
            if (validationresult.IsValid) 
            { 
              var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x=>x.Username == dto.Username && x.Password == dto.Password);
                if (user != null )
                {
                    var appuserdto = _mapper.Map<AppUserListDto>(user);
                    return new ResponseT<AppUserListDto>(ResponseType.Success,appuserdto);
                }
                return new ResponseT<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı veya şifre hatalı");
            }
            return new ResponseT<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı veya şifre boş olamaz");
        }
        public async Task<IResponseT<List<AppRoleListDto>>> GetRoleByUserIdAsync(int userid)
        {
            var roles =  await _uow.GetRepository<AppRole>().GetAllAsync(x=>x.AppUserRoles.Any(x=>x.AppUserId == userid));
            if (roles == null)
                return new ResponseT<List<AppRoleListDto>>(ResponseType.NotFound, "ilgili rol bulunamadı");
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            return new ResponseT<List<AppRoleListDto>>(ResponseType.Success, dto);
        }
    }
}
