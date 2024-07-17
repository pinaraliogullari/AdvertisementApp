using AdvertisementApp.UI.Models;
using AdvertisementApp.UI.ValidationRules;
using FluentValidation;

namespace AdvertisementApp.UI.Extensions
{
    public static class ServiceRegistirationExtension
    {
        public static void AddValidationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserCreateModel>,UserCreateModelValidator>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
