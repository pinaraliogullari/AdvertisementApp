using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AdvertisementApp.Shared.Enums;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementAppUserCreateDtoValidator:AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(x=>x.AdvertisementAppUserStatusId).NotEmpty();
            RuleFor(x=>x.AdvertisementId).NotEmpty();
            RuleFor(x=>x.AppUserId).NotEmpty();
            RuleFor(x=>x.CvPath).NotEmpty().WithMessage("Bir cv dosyası seçiniz.");
            RuleFor(x=>x.EndDate).NotEmpty().When(x=>x.MilitaryStatusId==(int)MilitaryStatusType.Tecilli).WithMessage("Tecil tarihi boş bırakılamaz.");
        }
    }
}
