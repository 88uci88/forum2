using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CulinaryForum.Models;

namespace CulinaryForum.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasKey(u => u.Id);

        builder
            .HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "user",
                    Email = "user@mygmail.com",
                    NormalizedEmail = "USER@MYGMAIL.COM",
                    NormalizedUserName = "USER",
                    PasswordHash = new PasswordHasher<UserEntity>().HashPassword(null, "naFvrJp3#")
                },
                new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    Email = "admin@mygmail.com",
                    NormalizedEmail = "ADMIN@MYGMAIL.COM",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = new PasswordHasher<UserEntity>().HashPassword(null, "naFvrJp3#")
                });
    }
}