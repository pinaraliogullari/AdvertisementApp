using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.Data.Configurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x=>x.Firstname).HasMaxLength(300).IsRequired();
            builder.Property(x=>x.Lastname).HasMaxLength(300).IsRequired();
            builder.Property(x=>x.Username).HasMaxLength(300).IsRequired();
            builder.Property(x=>x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x=>x.Password).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Gender).WithMany(y => y.AppUsers).HasForeignKey(x => x.GenderId);
        }
    }
}
