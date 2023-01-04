using Common;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponseT<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
    }
}
