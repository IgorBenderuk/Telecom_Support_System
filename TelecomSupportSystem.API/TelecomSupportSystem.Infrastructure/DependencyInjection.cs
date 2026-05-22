using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelecomSupportSystem.Application.Interfaces.Services;
using TelecomSupportSystem.Infrastructure.Extensions;
using TelecomSupportSystem.Infrastructure.Services;

namespace TelecomSupportSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureInfrastructureOptions(configuration);

            services.AddScoped<ITokenService, JwtService>();

            services.AddDatabase(configuration);
            services.AddIdentity();
            services.AddJwtAuthentication(configuration);

            return services;
        }
    }
}
