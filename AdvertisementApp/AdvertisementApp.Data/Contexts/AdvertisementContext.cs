using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdvertisementApp.Data.Contexts
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementAppUser> AdvertisementAppUser { get; set; }
        public DbSet<AdvertisementAppUserStatus> AdvertisementAppUserStatuses{ get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MilitaryStatus> MilitaryStatus { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)=>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        

    }
}
