using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AdvertisementAppUserStatusMapper:Profile
    {
        public AdvertisementAppUserStatusMapper()
        {
            CreateMap<AdvertisementAppUserStatus, AdvertisementAppUserStatusListDto>().ReverseMap();
        }
    }
}
