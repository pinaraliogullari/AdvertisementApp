using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AsvertisementMapper:Profile
    {
        public AsvertisementMapper()
        {
            CreateMap<Advertisement, AdvertisementListDto>().ReverseMap();
            CreateMap<Advertisement,AdvertisementUpdateDto>().ReverseMap();
            CreateMap<Advertisement,AdvertisementCreateDto>().ReverseMap();
        }
    }
}
