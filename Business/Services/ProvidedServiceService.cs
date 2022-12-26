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
    public class ProvidedServiceService : 
      Service<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceService
    {
    public ProvidedServiceService(
      IMapper mapper, IValidator<ProvidedServiceCreateDto> createdtovalidator, IValidator<ProvidedServiceUpdateDto> updatedtovalidator, IUow uow) : 
            base(mapper,createdtovalidator,updatedtovalidator,uow)
        {

        }
    }
}
