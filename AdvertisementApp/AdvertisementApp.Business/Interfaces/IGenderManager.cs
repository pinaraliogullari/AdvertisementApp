using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IGenderManager:IService<GenderCreaterDto,GenderUpdateDto,GenderListDto,Gender>
    {
    }
}
