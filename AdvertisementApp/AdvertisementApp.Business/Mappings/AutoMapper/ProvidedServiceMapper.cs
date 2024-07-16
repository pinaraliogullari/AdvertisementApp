using AdvertisementApp.Dtos.ProvidedServiceDtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class ProvidedServiceMapper:Profile
    {
        public ProvidedServiceMapper()
        {
            CreateMap<ProvidedServiceCreateDto,ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDto,ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceListDto,ProvidedService>().ReverseMap();
        }
    }
}
