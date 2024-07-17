using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.FluentValidation
{
    public class AppUserCreateDtoValidator:AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(x=>x.Firstname).NotEmpty();
            RuleFor(x=>x.Lastname).NotEmpty();
            RuleFor(x=>x.PhoneNumber).NotEmpty();
            RuleFor(x=>x.Username).NotEmpty();
            RuleFor(x=>x.GenderId).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
        }
    }
}
