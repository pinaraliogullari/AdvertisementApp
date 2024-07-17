using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.FluentValidation
{
    public class ProvidedServiceUpdateDtoValidator:AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceUpdateDtoValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.ImagePath).NotEmpty();
            RuleFor(x=>x.Title).NotEmpty();
        }
    }
}
