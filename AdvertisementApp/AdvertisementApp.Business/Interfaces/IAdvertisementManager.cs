using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AdvertisementApp.Shared;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementManager:IService<AdvertisementCreateDto, AdvertisementUpdateDto,AdvertisementListDto,Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}
