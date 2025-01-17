using BuildCompany.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildCompany.Domain;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<ServiceCategory> ServiceCategories { get; set; }

    public DbSet<Service> Services { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        string adminName = "admin";
        string roleAdminId = "3289A546-F831-4413-89D7-07011969314D";
        string userAdminId = "2D414837-BAC5-4B27-9E60-7AAF4B51BF35";

        builder.Entity<IdentityRole>()
            .HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper(),
            });

        builder.Entity<IdentityUser>()
            .HasData(new IdentityUser()
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), adminName),
                PhoneNumberConfirmed = true,
            });

        builder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>()
            {
                RoleId = roleAdminId,
                UserId = userAdminId,
            });
    }
}