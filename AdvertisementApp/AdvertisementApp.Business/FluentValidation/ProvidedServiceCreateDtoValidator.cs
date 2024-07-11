using AdvertisementApp.Dtos.ProvidedServiceDtos;
using FluentValidation;

namespace AdvertisementApp.Business.FluentValidation
{
    public class ProvidedServiceCreateDtoValidator :AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.ImagePath).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}
