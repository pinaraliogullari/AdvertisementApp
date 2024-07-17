using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Data.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AdvertisementApp.Shared;
using AutoMapper;
using FluentValidation;

namespace AdvertisementApp.Business.Services
{
    public class AppUserManager : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserManager
    {

        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createValidator;
        public AppUserManager(IMapper mapper, IUow uow, IValidator<AppUserCreateDto> createValidator, IValidator<AppUserUpdateDto> updateValidator) : base(mapper, uow, createValidator, updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success,dto);

                //await _uow.GetRepository<AppUser>().CreateAsync(user);
                //await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                //{
                //    AppRoleId= roleId,
                //   AppUser=user
                //});
            }
            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());

        }
    }
}
