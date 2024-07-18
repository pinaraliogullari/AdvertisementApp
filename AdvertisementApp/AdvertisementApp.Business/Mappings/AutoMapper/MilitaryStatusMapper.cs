using AdvertisementApp.Dtos.MilitaryStatusDto;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class MilitaryStatusMapper:Profile
    {
        public MilitaryStatusMapper()
        {
            CreateMap<MilitaryStatus, MilitaryStatusListDto>().ReverseMap();    
        }
    }
}
