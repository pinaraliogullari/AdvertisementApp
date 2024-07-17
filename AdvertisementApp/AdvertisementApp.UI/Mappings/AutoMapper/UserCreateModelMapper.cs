using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Models;
using AutoMapper;

namespace AdvertisementApp.UI.Mappings.AutoMapper
{
    public class UserCreateModelMapper:Profile
    {
        public UserCreateModelMapper()
        {
            CreateMap<UserCreateModel,AppUserCreateDto>();
        }
    }
}
