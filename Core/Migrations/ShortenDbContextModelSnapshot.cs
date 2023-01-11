﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShortenUrl.Core;

#nullable disable

namespace ShortenUrl.Core.Migrations
{
    [DbContext(typeof(ShortenDbContext))]
    partial class ShortenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShortenUrl.Core.Entities.ShortenedUrl", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Clicked")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginalUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShortenedUrls");
                });

            modelBuilder.Entity("ShortenUrl.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActice")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActice = true,
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 11, 19, 17, 54, 823, DateTimeKind.Local).AddTicks(1152),
                            Name = "System Admin",
                            Password = "sysadmin",
                            Role = "sysadmin",
                            Username = "sysadmin"
                        },
                        new
                        {
                            Id = 2,
                            IsActice = true,
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 11, 19, 17, 54, 823, DateTimeKind.Local).AddTicks(1164),
                            Name = "Admin",
                            Password = "admin",
                            Role = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 3,
                            IsActice = true,
                            ModifiedBy = 1,
                            ModifiedOn = new DateTime(2023, 1, 11, 19, 17, 54, 823, DateTimeKind.Local).AddTicks(1166),
                            Name = "User",
                            Password = "user",
                            Role = "user",
                            Username = "user"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
