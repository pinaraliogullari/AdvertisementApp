using AdvertisementApp.Dtos;
using AdvertisementApp.Shared;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserManager
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
    }
}
