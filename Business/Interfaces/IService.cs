using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Dtos.Interfaces;
using Dtos;
using Entities;

namespace Business.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto: class,IDto, new()
        where UpdateDto  : class, IUpdateDto, new()
        where ListDto : class,IDto, new()
        where T : BaseEntity
    
    {
       Task<IResponseT<CreateDto>> CreateAsync(CreateDto dto);

       Task<IResponseT<UpdateDto>> UpdateAsync(UpdateDto dto);


        Task<IResponseT<IDto>> GetByIdAsync<IDto>(int id);

        Task<IResponse> RemoveAsync(int id);

        Task<IResponseT<List<ListDto>>> GetAllAsync();
    }
}