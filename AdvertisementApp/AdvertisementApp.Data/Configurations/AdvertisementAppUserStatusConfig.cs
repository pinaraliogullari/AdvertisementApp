using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.Data.Configurations
{
    public class AdvertisementAppUserStatusConfig : IEntityTypeConfiguration<AdvertisementAppUserStatus>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUserStatus> builder)
        {
            builder.Property(x=>x.Definition).HasMaxLength(300).IsRequired();
        }
    }
}
