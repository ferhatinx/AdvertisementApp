using AutoMapper;
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
    public class AdvertisementService : 
        Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(
                                    IMapper mapper, 
                                    IValidator<AdvertisementCreateDto> createdtovalidator, 
                                    IValidator<AdvertisementUpdateDto> updatedtovalidator,
                                    IUow uow) : base(mapper,createdtovalidator,updatedtovalidator,uow)
        {
            _uow= uow;
            _mapper= mapper;
        }

        public async Task<IResponseT<List<AdvertisementListDto>>> GetActiveAsync()
        {
           var data = await _uow.GetRepository<Advertisement>().
                GetAllAsync(x=>x.Status,x=>x.CreateTime,Common.Enums.OrderByType.DESC);
           
           var dto = _mapper.Map<List<AdvertisementListDto>>(data);
           
           return new ResponseT<List<AdvertisementListDto>>(ResponseType.Success,dto);
        }
    }
}
