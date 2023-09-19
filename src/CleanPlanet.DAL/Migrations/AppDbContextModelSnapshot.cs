using System;
using CleanPlanet.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CleanPlanet.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Addresses.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("DistrictId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<int>("QuantityOfCar")
                        .HasColumnType("integer");

                    b.Property<long>("RegionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StreetId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("RegionId");

                    b.HasIndex("StreetId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CountryId = 233L,
                            CreatedAt = new DateTime(2023, 9, 15, 19, 46, 6, 886, DateTimeKind.Utc).AddTicks(396),
                            DistrictId = 182L,
                            IsDelete = false,
                            QuantityOfCar = 10,
                            RegionId = 12L,
                            StreetId = 1L
                        });
                });

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Addresses.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CountryCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Countries");

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Addresses.District", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("RegionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Districts");

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Addresses.Region", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 12L,
                            CountryId = 233L,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDelete = false,
                            Name = "Farg�ona viloyati"
                        });
                });

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Addresses.Street", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("DistrictId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Streets");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2023, 9, 15, 19, 46, 6, 886, DateTimeKind.Utc).AddTicks(452),
                            IsDelete = false,
                            Name = "Qang'il",
                            RegionId = 12L
                        });
                });

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Attachments.Attach", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Attachs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FileName = "City",
                            FilePath = "",
                            IsDelete = false
                        });
                });

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Cars.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AttachId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<int>("QunatityTrashCan")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AttachId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AttachId = 1L,
                            CreatedAt = new DateTime(2023, 9, 15, 19, 46, 6, 886, DateTimeKind.Utc).AddTicks(519),
                            IsDelete = false,
                            Number = "777ZZZ",
                            QunatityTrashCan = 20,
                            Type = "ISUZU"
                        });
                });

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Drivers.Driver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AttachId")
                        .HasColumnType("bigint");

                    b.Property<long>("CarId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AttachId");

                    b.HasIndex("CarId");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AttachId = 1L,
                            CarId = 1L,
                            CreatedAt = new DateTime(2023, 9, 15, 19, 46, 6, 886, DateTimeKind.Utc).AddTicks(561),
                            DateOfBirth = new DateTime(1992, 2, 1, 19, 0, 0, 0, DateTimeKind.Utc),
                            FirstName = "Bekzod",
                            IsDelete = false,
                            LastName = "Xokimov",
                            Password = "xokimoff",
                            Phone = "+998908976789",
                            Role = 3
                        });
                });

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Statistics.Statistic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("CleanPlanet.Domain.Entities.TrashCans.TrashCan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CarId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DueData")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CarId");

                    b.ToTable("TrashCans");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AddressId = 1L,
                            CarId = 1L,
                            CreatedAt = new DateTime(2023, 9, 15, 19, 46, 6, 886, DateTimeKind.Utc).AddTicks(577),
                            DueData = new DateTime(2023, 12, 11, 19, 0, 0, 0, DateTimeKind.Utc),
                            IsDelete = false
                        });
                });

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AddressId = 1L,
                            CreatedAt = new DateTime(2023, 9, 15, 19, 46, 6, 886, DateTimeKind.Utc).AddTicks(273),
                            Email = "nurmatovnurullo.n@gmail.com",
                            FirstName = "Nurullo",
                            IsDelete = false,
                            LastName = "Mansurjon",
                            Password = "Nurullo0816",
                            Phone = "+998942240816",
                            Role = 2
                        });
                });

            modelBuilder.Entity("CleanPlanet.Domain.Entities.Addresses.Address", b =>
                {
                    b.HasOne("CleanPlanet.Domain.Entities.Addresses.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanPlanet.Domain.Entities.Addresses.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanPlanet.Domain.Entities.Addresses.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanPlanet.Domain.Entities.Addresses.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId");

                    b.Navigation("Country");

                    b.Navigation("District");

                    b.Navigation("Region");

                    b.Navigation("Street");
                });

         }
    }
}
