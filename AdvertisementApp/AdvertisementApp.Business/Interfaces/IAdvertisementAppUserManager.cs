using AdvertisementApp.Dtos;
using AdvertisementApp.Shared;
using AdvertisementApp.Shared.Enums;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserManager
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
        Task<List<AdvertisementAppUserListDto>> GetListAsync(AdvertisementAppUserStatusType type);
        Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type);
    }
}
