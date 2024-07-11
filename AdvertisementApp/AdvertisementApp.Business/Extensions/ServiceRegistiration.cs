using AdvertisementApp.Data.Contexts;
using AdvertisementApp.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisementApp.Business.Extensions
{
    public static class ServiceRegistiration
    {
        public static void LoadMyContext(this IServiceCollection services)
        {
            services.AddDbContext<AdvertisementContext>(options => options.UseSqlServer(services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("SqlConnection")));

        }
        public static void LoadMyMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void LoadMyServices(this IServiceCollection services)
        {
            services.AddScoped<IUow, Uow>();
        }
    }
}
