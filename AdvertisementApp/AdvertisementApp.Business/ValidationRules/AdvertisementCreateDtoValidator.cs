using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.FluentValidation
{
    public class AdvertisementCreateDtoValidator:AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}
