﻿// <auto-generated />
using System;
using ArgonDashboard.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArgonDashboard.Migrations.Migrations
{
    [DbContext(typeof(ArgonDbContext))]
    [Migration("20230127221632_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("deleted_at");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("INTEGER")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.HasIndex(new[] { "Name" }, "roles_name_unique")
                        .IsUnique();

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                            CreatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            CreatedBy = 1L,
                            IsActive = true,
                            Name = "system",
                            NormalizedName = "SYSTEM",
                            UpdatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                            CreatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            CreatedBy = 1L,
                            IsActive = true,
                            Name = "admin",
                            NormalizedName = "ADMIN",
                            UpdatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 1L
                        },
                        new
                        {
                            Id = 3L,
                            ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                            CreatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            CreatedBy = 1L,
                            IsActive = true,
                            Name = "supervisor",
                            NormalizedName = "SUPERVISOR",
                            UpdatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 1L
                        },
                        new
                        {
                            Id = 4L,
                            ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                            CreatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            CreatedBy = 1L,
                            IsActive = true,
                            Name = "instructor",
                            NormalizedName = "INSTRUCTOR",
                            UpdatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 1L
                        },
                        new
                        {
                            Id = 5L,
                            ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                            CreatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            CreatedBy = 1L,
                            IsActive = true,
                            Name = "employee",
                            NormalizedName = "EMPLOYEE",
                            UpdatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 1L
                        });
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<long>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("role_claims", (string)null);
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex(new[] { "Email" }, "users_email_unique")
                        .IsUnique();

                    b.HasIndex(new[] { "UserName" }, "users_username_unique")
                        .IsUnique();

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d6e2c1f1-3a7b-4cf0-aea5-05deb4f12df7",
                            CreatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            CreatedBy = 1L,
                            Email = "admin@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@TEST.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEA0dFJ7ebrmyrqdtL1eV5ttvgEi+6KSfBo4SVQIuvwsiqzcc18PrmHJ+sg8beske+w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "27c0b512-9f7e-4ce7-bcff-6563379cbe20",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2021, 11, 15, 0, 53, 30, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 1L,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_claims", (string)null);
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("user_logins", (string)null);
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.UserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("user_role", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            RoleId = 1L
                        },
                        new
                        {
                            UserId = 1L,
                            RoleId = 2L
                        },
                        new
                        {
                            UserId = 1L,
                            RoleId = 3L
                        },
                        new
                        {
                            UserId = 1L,
                            RoleId = 4L
                        },
                        new
                        {
                            UserId = 1L,
                            RoleId = 5L
                        });
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.UserToken", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("user_tokens", (string)null);
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.RoleClaim", b =>
                {
                    b.HasOne("ArgonDashboard.Core.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.UserClaim", b =>
                {
                    b.HasOne("ArgonDashboard.Core.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.UserLogin", b =>
                {
                    b.HasOne("ArgonDashboard.Core.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.UserRole", b =>
                {
                    b.HasOne("ArgonDashboard.Core.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArgonDashboard.Core.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArgonDashboard.Core.Data.Entities.UserToken", b =>
                {
                    b.HasOne("ArgonDashboard.Core.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
