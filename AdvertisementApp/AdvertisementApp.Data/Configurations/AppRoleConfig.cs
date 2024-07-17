using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.Data.Configurations
{
    public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();
            builder.HasData(
                new AppRole
                {
                    Id = 3,
                    Definition = "Admin"
                }, 
                new AppRole
                {
                    Id = 4,
                    Definition = "Member"
                });


        }
    }
}
