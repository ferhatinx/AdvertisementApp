using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Business.ValidationRules;
using Common;
using DataAccess.UnitOfWork;
using Dtos.Interfaces;
using Entities;
using FluentValidation;

namespace Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity


    
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createdtovalidator;
        private readonly IValidator<UpdateDto> _updatedtovalidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createdtovalidator, IValidator<UpdateDto> updatedtovalidator, IUow uow)
        {
            _mapper = mapper;
            _createdtovalidator = createdtovalidator;
            _updatedtovalidator = updatedtovalidator;
            _uow = uow;
        }

        public async Task<IResponseT<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createdtovalidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().CreateAsync(createdEntity);
                await _uow.SaveChangesAsync();
                return new ResponseT<CreateDto>(ResponseType.Success,dto);
            }
            return new ResponseT<CreateDto>(dto,result.ConvertToCustomValidationError());
        }

        public async Task<IResponseT<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
            return new ResponseT<List<ListDto>>(ResponseType.Success,dto);
        }

        public async Task<IResponseT<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x=>x.Id == id);
            if (data == null)
                return new ResponseT<IDto>(ResponseType.NotFound, $"{id} numaralý id' ye ait data bulunamadý");
            var dto = _mapper.Map<IDto>(data);
            return new ResponseT<IDto>(ResponseType.Success, dto);
            
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().FindAsync(id);

            if (data == null)
                return new Response(ResponseType.NotFound, $"{id} numaralý id bulunamadý");
            _uow.GetRepository<T>().Remove(data);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);

            
        }

        public async Task<IResponseT<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updatedtovalidator.Validate(dto);
            if (result.IsValid)
            {
                
               var unchangedData = await _uow.GetRepository<T>().FindAsync(dto.ID);
                if (unchangedData == null)
                {
                    return new ResponseT<UpdateDto>(ResponseType.NotFound, $"{dto.ID} id'ye sahip data bulunamadý ");
                   
                    
                }
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Update(entity, unchangedData);
                await _uow.SaveChangesAsync();
                return new ResponseT<UpdateDto>(ResponseType.Success, dto); 
            }
            return new ResponseT<UpdateDto>(dto,result.ConvertToCustomValidationError());
                
               
                

                
            

            
        }
    }
}