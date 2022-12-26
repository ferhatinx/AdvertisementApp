using Common;
using Dtos;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAdvertisementService : 
        IService<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Advertisement>
    {
        Task<IResponseT<List<AdvertisementListDto>>> GetActiveAsync();
    }
}
