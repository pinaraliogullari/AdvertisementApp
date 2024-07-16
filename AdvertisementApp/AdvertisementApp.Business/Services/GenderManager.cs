using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Data.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    public class GenderManager:Service<GenderCreaterDto,GenderUpdateDto,GenderListDto,Gender>,IGenderManager
    {
        public GenderManager(IMapper mapper, IUow uow,IValidator<GenderCreaterDto> createValidator, IValidator<GenderUpdateDto> updateValidator):base(mapper, uow, createValidator, updateValidator)
        {
            
        }
    }
}
