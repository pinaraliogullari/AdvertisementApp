using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAppUserManager:IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
    }
}
