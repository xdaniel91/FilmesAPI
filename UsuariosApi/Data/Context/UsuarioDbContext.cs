using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UsuariosApi.Models;

namespace UsuariosApi.Data.Context
{
    public class UsuarioDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opt, IConfiguration configuration) : base(opt)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new ApplicationUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("admininfo:password"));

            var adminRole = new IdentityRole<int>
            {
                Id = 9999,
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var UserRole = new IdentityUserRole<int>
            {
                RoleId = 9999,
                UserId = 9999
            };

            var regularRole = new IdentityRole<int>
            {
                Id = 8888,
                Name = "regular",
                NormalizedName = "REGULAR"
            };

            builder.Entity<IdentityRole<int>>().HasData(adminRole);
            builder.Entity<IdentityRole<int>>().HasData(regularRole);
            builder.Entity<ApplicationUser>().HasData(admin);
            builder.Entity<IdentityUserRole<int>>().HasData(UserRole);
        }
    }
}