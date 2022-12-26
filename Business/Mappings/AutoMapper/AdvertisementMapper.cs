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
    public class AdvertisementMapper : Profile
    {
        public AdvertisementMapper()
        {
            CreateMap< Advertisement, AdvertisementListDto>().ReverseMap();
            CreateMap<Advertisement,AdvertisementCreateDto>().ReverseMap();
            CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap();

        }
    }
}
