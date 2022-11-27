using Common.Authorization;
using Common.Interfaces;
using Common.Options;
using Common.Services;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Common.Configuration
{
    public static class IServiceCollectionCommonExtensions
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));
            services.ConfigureCommonAuthentication(configuration);
            services.ConfigurePolicy();

            return services;
        }

        public static IServiceCollection ConfigureCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExcelService, ExcelService>();

            return services;
        }

        private static IServiceCollection ConfigureCommonAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            var keyBytes = Encoding.ASCII.GetBytes(configuration["AuthorizationOptions:JwtKey"]);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        NameClaimType = JwtClaimTypes.Name,
                        RoleClaimType = JwtClaimTypes.Role,
                        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                        ValidIssuer = configuration["AuthorizationOptions:Issuer"],
                        ValidAudience = configuration["AuthorizationOptions:Audience"],
                    };
                });

            return services;
        }

        private static IServiceCollection ConfigurePolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(ReadMyRoles.Admin, policy => policy.RequireAuthenticatedUser()
                .RequireClaim(JwtClaimTypes.Role, ReadMyRoles.Admin)
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme));

                options.AddPolicy(ReadMyRoles.ProjectManager, policy => policy.RequireAuthenticatedUser()
                .RequireClaim(JwtClaimTypes.Role, ReadMyRoles.Admin, ReadMyRoles.ProjectManager)
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme));

                options.AddPolicy(ReadMyRoles.Worker, policy => policy.RequireAuthenticatedUser()
                .RequireClaim(JwtClaimTypes.Role, ReadMyRoles.Admin, ReadMyRoles.ProjectManager, ReadMyRoles.Worker)
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme));

                options.DefaultPolicy = options.GetPolicy(ReadMyRoles.Worker);
            });

            return services;
        }

        private static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>())
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });
            });

            return services;
        }
    }
}
