using AdvertisementApp.Business.FluentValidation;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Business.Services;
using AdvertisementApp.Data.Contexts;
using AdvertisementApp.Data.UnitOfWork;
using AdvertisementApp.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisementApp.Business.Extensions
{
    public static class ServiceRegistiration
    {
        public static void AddContext(this IServiceCollection services)
        {
            services.AddDbContext<AdvertisementContext>(options => options.UseSqlServer(services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("SqlConnection")));

        }
        public static void AddValidationAndMappingServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IValidator<ProvidedServiceCreateDto>,ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>,ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>,AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>,AdvertisementUpdateDtoValidator>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IProvidedServiceManager, ProvidedServiceManager>();
            services.AddScoped<IAdvertisementManager, AdvertisementManager>();
        }
    }
}
