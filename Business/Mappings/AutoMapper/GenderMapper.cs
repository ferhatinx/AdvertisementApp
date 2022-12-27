using AutoMapper;
using Dtos;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings.AutoMapper
{
    public class GenderMapper : Profile
    {
        public GenderMapper() 
        { 
            CreateMap<Gender,GenderCreateDto>().ReverseMap();
            CreateMap<Gender,GenderUpdateDto>().ReverseMap();
            CreateMap<Gender,GenderListDto>().ReverseMap();
        }
    }
}
