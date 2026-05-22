using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelecomSupportSystem.Infrastructure.Extensions;

namespace TelecomSupportSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureInfrastructureOptions(configuration);

            services.AddDatabase(configuration);
            services.AddIdentity();
            services.AddJwtAuthentication(configuration);

            return services;
        }
    }
}
