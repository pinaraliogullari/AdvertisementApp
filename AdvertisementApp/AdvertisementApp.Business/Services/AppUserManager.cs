using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Data.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    public class AppUserManager:Service<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>,IAppUserManager
    {
        public AppUserManager(IMapper mapper,IUow uow,IValidator<AppUserCreateDto> createValidator,IValidator<AppUserUpdateDto> updateValidator):base(mapper, uow, createValidator, updateValidator)
        {
            
        }
    }
}
