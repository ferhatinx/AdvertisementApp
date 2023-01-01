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
    public interface IAppUserService : IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
        Task<IResponseT<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleid);

        Task<IResponseT<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto);

        Task<IResponseT<List<AppRoleListDto>>> GetRoleByUserIdAsync(int userid);
    }
}
