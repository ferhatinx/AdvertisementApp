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
    public class AppRoleMapper : Profile
    {
        public AppRoleMapper()
        {
            CreateMap<AppRole,AppRoleListDto>().ReverseMap();
        }
    }
}
