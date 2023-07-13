﻿// <auto-generated />
using System;
using Data.Concrete.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ContextKargo))]
    [Migration("20230710071137_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("CenterId")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsRequired()
                        .HasColumnType("text");

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
                            CenterId = 0,
                            ConcurrencyStamp = "cc5363d9-e2ad-4d0c-9a23-7cdec5a53097",
                            IsActive = true,
                            LineName = "Diyarbakır Hattı",
                            LineType = 1
                        },
                        new
                        {
                            LineId = 2,
                            CenterId = 0,
                            ConcurrencyStamp = "64f53933-5a21-4700-890e-c2d9665a1045",
                            IsActive = true,
                            LineName = "Mardin Hattı",
                            LineType = 1
                        },
                        new
                        {
                            LineId = 3,
                            CenterId = 0,
                            ConcurrencyStamp = "72172875-8e9e-49ac-8914-33fe699f0c58",
                            IsActive = true,
                            LineName = "Mersin Hattı",
                            LineType = 1
                        },
                        new
                        {
                            LineId = 4,
                            CenterId = 0,
                            ConcurrencyStamp = "d816cabd-7e8a-4d66-880b-f18adb873414",
                            IsActive = true,
                            LineName = "Ankara Hattı",
                            LineType = 1
                        },
                        new
                        {
                            LineId = 5,
                            CenterId = 0,
                            ConcurrencyStamp = "488a1d7c-7076-44a7-803d-46ac06be0554",
                            IsActive = true,
                            LineName = "İstanbul Hattı",
                            LineType = 2
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Agenta",
                            NormalizedName = "AGENTA"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TransferCenter",
                            NormalizedName = "CENTER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Entity.Concrete.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

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

                    b.HasIndex("UnitId");

                    b.ToTable("Station");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "8f08958e-d224-45d5-bd4f-5c287044f165",
                            IsActive = true,
                            LineId = 1,
                            OrderNumber = 1,
                            StationName = "durak1",
                            UnitId = 1
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "20eb8463-00b7-4da2-b01d-a071e7147e3b",
                            IsActive = true,
                            LineId = 1,
                            OrderNumber = 2,
                            StationName = "durak2",
                            UnitId = 2
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "b3f4324d-c82a-4231-ae42-b24ed29811d3",
                            IsActive = true,
                            LineId = 1,
                            OrderNumber = 3,
                            StationName = "durak3",
                            UnitId = 3
                        },
                        new
                        {
                            Id = 4,
                            ConcurrencyStamp = "bd364afc-9d06-4d6a-9dd8-afd0f696810e",
                            IsActive = true,
                            LineId = 2,
                            OrderNumber = 1,
                            StationName = "durak4",
                            UnitId = 4
                        },
                        new
                        {
                            Id = 5,
                            ConcurrencyStamp = "923ba6d3-3a20-4377-a613-7c3b3fe430f4",
                            IsActive = true,
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

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ManagerSurname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NeighBourHood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
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
                        .IsRequired()
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

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("UnitId");

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
                            ConcurrencyStamp = "fc7ccdb3-d719-4005-83cb-8a05f5adc7c2",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "kadir",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            Street = "sokak1",
                            UnitName = "agenta1",
                            CenterId = 1
                        },
                        new
                        {
                            Id = 7,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            ConcurrencyStamp = "f26deb63-c0f8-4cb3-9132-12d803e9e402",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "kadir",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            Street = "sokak1",
                            UnitName = "agenta2",
                            CenterId = 1
                        },
                        new
                        {
                            Id = 8,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            ConcurrencyStamp = "ec231d1e-1891-4e94-932b-5683e4a1d038",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "kadir",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            Street = "sokak1",
                            UnitName = "agenta3",
                            CenterId = 1
                        },
                        new
                        {
                            Id = 9,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            ConcurrencyStamp = "cac88b93-edc2-48b6-b739-4449de433846",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "kadir",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            Street = "sokak1",
                            UnitName = "agenta4",
                            CenterId = 1
                        },
                        new
                        {
                            Id = 10,
                            AddressDetail = "Amed merkez",
                            City = "Diyarbakır",
                            ConcurrencyStamp = "a67c11a7-d614-40c1-ae5b-b875ac0f09d5",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "kadir",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
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
                            ConcurrencyStamp = "69fc3b04-79de-416b-a277-1e1bac06448d",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "kadir@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "kadir",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            Street = "sokak1",
                            UnitName = "Name1"
                        },
                        new
                        {
                            Id = 2,
                            AddressDetail = "Mardin merkez",
                            City = "Mardin",
                            ConcurrencyStamp = "1626ce7c-1211-4035-be88-acb8a5dd5f85",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "muaz@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "muaz",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            Street = "sokak1",
                            UnitName = "Name2"
                        },
                        new
                        {
                            Id = 3,
                            AddressDetail = "Konya merkez",
                            City = "Konya",
                            ConcurrencyStamp = "c8720fad-b419-4fe1-9563-a428a9d1e026",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "yusuf@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "yusuf",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            Street = "sokak1",
                            UnitName = "Name3"
                        },
                        new
                        {
                            Id = 4,
                            AddressDetail = "Ankara merkez",
                            City = "Ankara",
                            ConcurrencyStamp = "a3637cef-558e-40c0-a1c7-78315645d94c",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "ahmet@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "ahmet",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
                            Street = "sokak1",
                            UnitName = "Name4"
                        },
                        new
                        {
                            Id = 5,
                            AddressDetail = "İstanbul merkez",
                            City = "İstanbul",
                            ConcurrencyStamp = "291c80b1-f9ae-4a71-8f1e-4e02c5be9b46",
                            Description = "Description",
                            District = "Bağlar",
                            Email = "mehmet@gmail.com",
                            Gsm = "085012356",
                            IsDeleted = false,
                            ManagerName = "mehmet",
                            ManagerSurname = "Çabuk",
                            NeighBourHood = "mahalle1",
                            PhoneNumber = "05123456789",
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

                    b.HasOne("Entity.Concrete.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Entity.Concrete.User", b =>
                {
                    b.HasOne("Entity.Concrete.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
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
