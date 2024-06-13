using CulinaryForum.Models;
using Microsoft.AspNetCore.Identity;

namespace CulinaryForum.Data;

public static class RolesData
{
    private static readonly string[] Roles = ["Admin", "Moderator", "User"];

    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<UserEntity>>();

        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Назначение роли "Admin" пользователю "admin"
        var adminUser = await userManager.FindByEmailAsync("admin@mygmail.com");
        if (adminUser is not null && !await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}