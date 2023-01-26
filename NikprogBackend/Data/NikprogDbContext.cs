using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NikprogBackend.Models.UserHandling;
using NikprogBackend.Models;
using NikprogBackend.Models.CourseMaterials;

namespace NikprogBackend.Data
{
    public class NikprogDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<NikprogUser> AppUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<MaterialInfo> MaterialInfos { get; set; }

        public NikprogDbContext(DbContextOptions<NikprogDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //PasswordHasher<NikprogUser> pwHasher = new PasswordHasher<NikprogUser>();

            NikprogUser moni = new NikprogUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "q4nisq@stud.uni-obuda.hu",
                FirstName = "Mónika",
                LastName = "Tóth",
                UserName = "q4nisq@stud.uni-obuda.hu",
                NormalizedUserName = "Q4NSIQ@STUD.UNI-OBUDA.HU",
                LoginMode = LoginMode.microsoft
            };
            //moni.PasswordHash = pwHasher.HashPassword(moni, "Almafa123"); //Environment.GetEnvironmentVariable("NIKPROG_ADMIN_PW");

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

            builder.Entity<Course>()
               .HasMany(c => c.Modules)
               .WithOne(m => m.Course)
               .HasForeignKey(m => m.CourseId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Module>()
                .HasMany(m => m.MaterialInfos)
                .WithOne(mat => mat.Module)
                .HasForeignKey(mat => mat.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}