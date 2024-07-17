using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.FluentValidation
{
    public class GenderCreateDtoValidator:AbstractValidator<GenderCreaterDto>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
