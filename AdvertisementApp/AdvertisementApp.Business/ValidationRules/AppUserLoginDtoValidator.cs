using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules
{
    public class AppUserLoginDtoValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x=>x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Parola  boş olamaz"); ;
        }
    }
}
