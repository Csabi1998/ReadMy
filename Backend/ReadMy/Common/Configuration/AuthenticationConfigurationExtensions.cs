using System.IdentityModel.Tokens.Jwt;
using System.Text;

using Common.Authorization;
using Common.Options;
using Common.Services;

using IdentityModel;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Common.Configuration
{
    public static class AuthenticationConfigurationExtensions
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));
            services.ConfigureCommonAuthentication(configuration);

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
    }
}
