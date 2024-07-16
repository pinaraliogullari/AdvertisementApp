using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class GenderMapper:Profile
    {
        public GenderMapper()
        {
            CreateMap<Gender, GenderListDto>().ReverseMap();
            CreateMap<Gender, GenderCreaterDto>().ReverseMap();
            CreateMap<Gender,GenderUpdateDto>().ReverseMap();
        }
    }
}
