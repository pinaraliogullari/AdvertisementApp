using AdvertisementApp.Dtos.AppRoleDtos;
using AdvertisementApp.Entities;
using AutoMapper;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppRoleMapper:Profile
    {
        public AppRoleMapper()
        {
            CreateMap<AppRole, AppRoleListDto>().ReverseMap();
        }
    }
}
