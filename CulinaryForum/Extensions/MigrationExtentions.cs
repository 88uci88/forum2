using Microsoft.EntityFrameworkCore;
using CulinaryForum.Data;

namespace CulinaryForum.Extensions;

public static class MigrationExtentions
{
    public static void ApplyMigrate(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        context.Database.Migrate();
    }
}