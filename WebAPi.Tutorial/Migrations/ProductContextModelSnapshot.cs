﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPi.Tutorial.Data;

#nullable disable

namespace WebAPi.Tutorial.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPi.Tutorial.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 7, 19, 14, 32, 17, 204, DateTimeKind.Local).AddTicks(5753),
                            Name = "Bilgisayar",
                            Price = 45000m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 6, 22, 14, 32, 17, 204, DateTimeKind.Local).AddTicks(5773),
                            Name = "Telefon",
                            Price = 20000m,
                            Stock = 500
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 5, 23, 14, 32, 17, 204, DateTimeKind.Local).AddTicks(5774),
                            Name = "Klavye",
                            Price = 5000m,
                            Stock = 1000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
