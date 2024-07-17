using AdvertisementApp.UI.Models;
using FluentValidation;

namespace AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {

        public UserCreateModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola minimum 3 karakter olmalıdır.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı adı minimum 3 karakter olmalıdır.");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur.");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad boş olamaz."); ;
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Soyad boş olamaz."); ;
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz."); ;
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CannotFirstName(x.Username, x.Firstname)).WithMessage("Username cannot contain firstname").When(x => x.Username != null && x.Firstname != null);
         

        }
        private bool CannotFirstName(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
