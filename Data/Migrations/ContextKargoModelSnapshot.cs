﻿// <auto-generated />
using System;
using Data.Concrete.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ContextKargo))]
    partial class ContextKargoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entity.Concrete.Line", b =>
                {
                    b.Property<int>("LineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LineId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LineName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LineType")
                        .HasColumnType("integer");

                    b.HasKey("LineId");

                    b.ToTable("Lines");

                    b.HasData(
                        new
                        {
                            LineId = 1,
                            IsActive = true,
                            LineName = "Diyarbakır Hattı",
                            LineType = 1
                        },
                        new
                        {
                            LineId = 2,
                            IsActive = true,
                            LineName = "Mardin Hattı",
                            LineType = 1
                        },
                        new
                        {
                            LineId = 3,
                            IsActive = true,
                            LineName = "Mersin Hattı",
                            LineType = 1
                        },
                        new
                        {
                            LineId = 4,
                            IsActive = true,
                            LineName = "Ankara Hattı",
                            LineType = 1
                        },
                        new
                        {
                            LineId = 5,
                            IsActive = true,
                            LineName = "İstanbul Hattı",
                            LineType = 1
                        });
                });

            modelBuilder.Entity("Entity.Concrete.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Entity.Concrete.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LineId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("integer");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LineId");

                    b.ToTable("Station");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LineId = 1,
                            OrderNumber = 1,
                            StationName = "durak1",
                            UnitId = 1
                        },
                        new
                        {
                            Id = 2,
                            LineId = 1,
                            OrderNumber = 2,
                            StationName = "durak2",
                            UnitId = 2
                        },
                        new
                        {
                            Id = 3,
                            LineId = 1,
                            OrderNumber = 3,
                            StationName = "durak3",
                            UnitId = 3
                        },
                        new
                        {
                            Id = 4,
                            LineId = 2,
                            OrderNumber = 1,
                            StationName = "durak4",
                            UnitId = 4
                        },
                        new
                        {
                            Id = 5,
                            LineId = 2,
                            OrderNumber = 2,
                            StationName = "durak5",
                            UnitId = 5
                        });
                });

            modelBuilder.Entity("Entity.Concrete.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressDetail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("boolean");

                    b.Property<string>("NeighBourHood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ResponsibleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ResponsibleSurname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Unit");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Entity.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entity.Concrete.Agenta", b =>
                {
                    b.HasBaseType("Entity.Concrete.Unit");

                    b.Property<int>("CenterId")
                        .HasColumnType("integer");

                    b.HasIndex("CenterId");

                    b.HasDiscriminator().HasValue("Agenta");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "kadir",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "agenta1",
                            CenterId = 1
                        },
                        new
                        {
                            Id = 7,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "kadir",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "agenta2",
                            CenterId = 1
                        },
                        new
                        {
                            Id = 8,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "kadir",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "agenta3",
                            CenterId = 1
                        },
                        new
                        {
                            Id = 9,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "kadir",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "agenta4",
                            CenterId = 1
                        },
                        new
                        {
                            Id = 10,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "kadir",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "agenta5",
                            CenterId = 1
                        });
                });

            modelBuilder.Entity("Entity.Concrete.TransferCenter", b =>
                {
                    b.HasBaseType("Entity.Concrete.Unit");

                    b.HasDiscriminator().HasValue("TransferCenter");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "kadir",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "Name1"
                        },
                        new
                        {
                            Id = 2,
                            AddressDetail = "Mardin merkez",
                            City = "Mardin",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "muaz@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "muaz",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "Name2"
                        },
                        new
                        {
                            Id = 3,
                            AddressDetail = "Konya merkez",
                            City = "Konya",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "yusuf@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "yusuf",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "Name3"
                        },
                        new
                        {
                            Id = 4,
                            AddressDetail = "Ankara merkez",
                            City = "Ankara",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "ahmet@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "ahmet",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "Name4"
                        },
                        new
                        {
                            Id = 5,
                            AddressDetail = "İstanbul merkez",
                            City = "İstanbul",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "mehmet@gmail.com",
                            Gsm = "085012356",
                            IsBanned = false,
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            ResponsibleName = "mehmet",
                            ResponsibleSurname = "Çabuk",
                            Street = "sokak1",
                            UnitName = "Name5"
                        });
                });

            modelBuilder.Entity("Entity.Concrete.Station", b =>
                {
                    b.HasOne("Entity.Concrete.Line", "Line")
                        .WithMany("Stations")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Entity.Concrete.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Entity.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Entity.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Entity.Concrete.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Entity.Concrete.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.Concrete.Agenta", b =>
                {
                    b.HasOne("Entity.Concrete.TransferCenter", "TransferCenter")
                        .WithMany("Agentas")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransferCenter");
                });

            modelBuilder.Entity("Entity.Concrete.Line", b =>
                {
                    b.Navigation("Stations");
                });

            modelBuilder.Entity("Entity.Concrete.TransferCenter", b =>
                {
                    b.Navigation("Agentas");
                });
#pragma warning restore 612, 618
        }
    }
}
