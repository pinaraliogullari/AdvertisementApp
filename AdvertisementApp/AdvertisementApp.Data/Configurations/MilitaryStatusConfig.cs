using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.Data.Configurations
{
    public class MilitaryStatusConfig : IEntityTypeConfiguration<MilitaryStatus>
    {
        public void Configure(EntityTypeBuilder<MilitaryStatus> builder)
        {
            builder.Property(x=>x.Definition).HasMaxLength(300).IsRequired();
        }
    }
}
