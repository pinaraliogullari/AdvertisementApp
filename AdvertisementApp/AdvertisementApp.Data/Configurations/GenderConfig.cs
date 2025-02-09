﻿using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.Data.Configurations
{
    public class GenderConfig : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();
            builder.HasData(
                new Gender
                {
                    Id = 1,
                    Definition = "Kadın"
                }, new Gender
                {
                    Id = 2,
                    Definition = "Erkek"
                }
            );
        }
    }
}
