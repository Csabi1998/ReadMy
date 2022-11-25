using Domain.Entities;
using Infrastructure.DbSeed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MigrateDatabase<TContext>(this WebApplication app) where TContext : DbContext
    {
        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            var context = serviceProvider.GetRequiredService<TContext>();
            context.Database.Migrate();
        }

        return app;
    }

    public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ReadMyDbContext>();

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ReadMyUser>>();

            await DbSeeder.SeedDatabase(services, context, roleManager, userManager);
        }

        return host;
    }
}
