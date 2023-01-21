using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NikprogBackend.Models.UserHandling;

namespace NikprogBackend.Data
{
    public class NikprogDbContext : IdentityDbContext<IdentityUser>
    {
        public NikprogDbContext(DbContextOptions<NikprogDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            PasswordHasher<NikprogUser> pwHasher = new PasswordHasher<NikprogUser>();

            NikprogUser moni = new NikprogUser
            {
                Id = Guid.NewGuid().ToString(),
                BirthDate = new DateTime(1991, 5, 25),
                Sex = Sex.male,
                Email = "0monika01@gmail.com",
                EmailConfirmed = true,
                FirstName = "Mónika",
                LastName = "Tóth",
                UserName = "0monika01@gmail.com",
                NormalizedUserName = "0MONIKA01@GMAIL.COM"
            };
            moni.PasswordHash = pwHasher.HashPassword(moni, "Almafa123"); //Environment.GetEnvironmentVariable("NIKPROG_ADMIN_PW");

            builder.Entity<NikprogUser>().HasData(moni);

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Student", NormalizedName = "STUDENT" },
                new { Id = "3", Name = "Teacher", NormalizedName = "TEACHER" }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = moni.Id
            });

            base.OnModelCreating(builder);
        }
    }
}