using Common.Authorization;
using Common.Options;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(IServiceCollectionExtensions).Assembly);

            return services;
        }
    }
}
