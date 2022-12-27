using AutoMapper;
using Business.Interfaces;
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
    public class AppUserService : Service<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser> , IAppUserService
    {
        public AppUserService(IMapper mapper,IValidator<AppUserCreateDto> createdtovalidator, IValidator<AppUserUpdateDto> updatedtovalidator,IUow uow) : 
            base(mapper,createdtovalidator,updatedtovalidator,uow)
        {

        } 
    }
}
