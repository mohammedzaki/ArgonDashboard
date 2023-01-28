using ArgonDashboard.Core.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgonDashboard.Core.Data
{
    public partial class ArgonDbContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ArgonDbContext()
        {
        }

        public ArgonDbContext(DbContextOptions<ArgonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.ToTable("users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.ToTable("roles");

            });
            modelBuilder.Entity<UserRole>().ToTable("user_role");
            modelBuilder.Entity<UserClaim>().ToTable("user_claims");
            modelBuilder.Entity<UserLogin>().ToTable("user_logins");
            modelBuilder.Entity<RoleClaim>().ToTable("role_claims");
            modelBuilder.Entity<UserToken>().ToTable("user_tokens");

            OnModelCreatingPartial(modelBuilder);

            SeedInitialData(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            //Seeding Roles table 
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                    Name = "system",
                    NormalizedName = "system".ToUpper(),
                    IsActive = true,
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30")
                },
                new Role
                {
                    Id = 2,
                    ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                    Name = "admin",
                    NormalizedName = "admin".ToUpper(),
                    IsActive = true,
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30")
                },
                new Role
                {
                    Id = 3,
                    ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                    Name = "supervisor",
                    NormalizedName = "supervisor".ToUpper(),
                    IsActive = true,
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30")
                },
                new Role
                {
                    Id = 4,
                    ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                    Name = "instructor",
                    NormalizedName = "instructor".ToUpper(),
                    IsActive = true,
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30")
                },
                new Role
                {
                    Id = 5,
                    ConcurrencyStamp = "167860ad-4ade-4725-92b9-d8b57815b919",
                    Name = "employee",
                    NormalizedName = "employee".ToUpper(),
                    IsActive = true,
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30")
                }
            );

            //a hasher to hash the password before seeding the user to the db
            // 
            //var hasher = new PasswordHasher<User>();
            //var SecurityStamp = Guid.NewGuid().ToString();
            //var password = hasher.HashPassword(null, "#$3_!4&7F?Zb"); // AQAAAAEAACcQAAAAEA0dFJ7ebrmyrqdtL1eV5ttvgEi+6KSfBo4SVQIuvwsiqzcc18PrmHJ+sg8beske+w==

            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    PasswordHash = "AQAAAAEAACcQAAAAEA0dFJ7ebrmyrqdtL1eV5ttvgEi+6KSfBo4SVQIuvwsiqzcc18PrmHJ+sg8beske+w==", // = "#$3_!4&7F?Zb"
                    Email = "admin@test.com",
                    CreatedBy = 1,
                    UpdatedBy = 1,
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    NormalizedUserName = "admin".ToUpper(),
                    NormalizedEmail = "admin@test.com".ToUpper(),
                    ConcurrencyStamp = "d6e2c1f1-3a7b-4cf0-aea5-05deb4f12df7",
                    SecurityStamp = "27c0b512-9f7e-4ce7-bcff-6563379cbe20",
                    EmailConfirmed = true
                }
            );

            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserId = 1,
                    RoleId = 1
                },
                new UserRole
                {
                    UserId = 1,
                    RoleId = 2
                },
                new UserRole
                {
                    UserId = 1,
                    RoleId = 3
                },
                new UserRole
                {
                    UserId = 1,
                    RoleId = 4
                },
                new UserRole
                {
                    UserId = 1,
                    RoleId = 5
                }
            );
        }
    }
}
