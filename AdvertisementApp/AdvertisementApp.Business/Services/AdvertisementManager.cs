using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Data.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AdvertisementApp.Shared;
using AdvertisementApp.Shared.Enums;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    public class AdvertisementManager : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementManager
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

      
        public AdvertisementManager(IMapper mapper, IUow uow,IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator ):base(mapper,uow, createDtoValidator, updateDtoValidator)
        {
            _uow = uow;
            _mapper= mapper;
        }
        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync()
        {
            var data= await  _uow.GetRepository<Advertisement>().GetAllAsync(x => x.Status, x => x.CreateDate, OrderByType.DESC);
            var dto= _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Success,dto);
        }
    }
}
