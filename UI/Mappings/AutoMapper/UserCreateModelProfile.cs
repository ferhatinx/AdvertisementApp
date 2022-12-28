using AutoMapper;
using Dtos;
using UI.Models;

namespace UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile : Profile    
    {
        public UserCreateModelProfile()
        {
               CreateMap<UserCreateModel,AppUserCreateDto>().ReverseMap();
        }
    }
}
