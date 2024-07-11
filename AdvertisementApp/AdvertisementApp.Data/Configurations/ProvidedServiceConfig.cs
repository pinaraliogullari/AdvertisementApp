using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.Data.Configurations
{
    public class ProvidedServiceConfig : IEntityTypeConfiguration<ProvidedService>
    {
        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x=>x.Title).HasMaxLength(300).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
            builder.Property(x=>x.ImagePath).HasMaxLength(500).IsRequired();
        }
    }
}
