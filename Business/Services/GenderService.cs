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
    public class GenderService : Service<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>,IGenderService
    {
        public GenderService(IMapper mapper, IValidator<GenderCreateDto> createdtovalidator, IValidator<GenderUpdateDto> updatedtovalidator, IUow uow) : 
            base(mapper, createdtovalidator, updatedtovalidator, uow)
        {

        }
}
}
