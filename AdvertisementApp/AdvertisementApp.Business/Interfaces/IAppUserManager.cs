using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AdvertisementApp.Shared;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAppUserManager:IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId);
    }
}
