using AdvertisementApp.Dtos;
using AdvertisementApp.Dtos.AppRoleDtos;
using AdvertisementApp.Entities;
using AdvertisementApp.Shared;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAppUserManager:IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId);
        Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId);
    }
}
