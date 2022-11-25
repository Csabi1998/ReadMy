using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class IServiceCollectionExtensions
{
    public static void ConfigureDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDbContext(configuration);
        services.ConfigureIdentity();
    }

    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ReadMyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    private static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ReadMyUser>(options => options.SignIn.RequireConfirmedAccount = false)
          .AddRoles<IdentityRole>()
          .AddDefaultTokenProviders()
          .AddEntityFrameworkStores<ReadMyDbContext>();
    }
}
