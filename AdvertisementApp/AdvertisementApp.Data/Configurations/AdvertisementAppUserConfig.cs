using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.Data.Configurations
{
    public class AdvertisementAppUserConfig : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            builder.HasIndex(x => new { x.AdvertisementId, x.AppUserId }).IsUnique(); //Birden fazla mükerrer kayıt girilemeyecek. Yani bir kişi aynı ilana tekra başvuramayacak. 
            builder.Property(x=>x.CvPath).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Advertisement).WithMany(y => y.AdvertisementAppUsers).HasForeignKey(x=>x.AdvertisementId);
            builder.HasOne(x=>x.AppUser).WithMany(y=>y.AdvertisementAppUsers).HasForeignKey(x=> x.AppUserId);
            builder.HasOne(x => x.AdvertisementAppUserStatus).WithMany(y => y.AdvertisementAppUsers).HasForeignKey(x => x.AdvertisementAppUserStatusId);
            builder.HasOne(x => x.MilitaryStatus).WithMany(y => y.AdvertisementAppUsers).HasForeignKey(x => x.MilitaryStatusId);
        }
    }
}
