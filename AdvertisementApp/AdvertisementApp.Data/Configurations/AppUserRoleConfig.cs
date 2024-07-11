using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.Data.Configurations
{
    public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasIndex(x => new { x.AppUserId, x.AppRoleId }).IsUnique();
            builder.HasOne(x => x.AppRole).WithMany(y => y.AppUserRoles).HasForeignKey(x => x.AppRoleId);
            builder.HasOne(x => x.AppUser).WithMany(y => y.AppUserRoles).HasForeignKey(x => x.AppUserId);
        }
    }
}
