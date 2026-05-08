using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelecomSupportSystem.Infrastructure.Options;

namespace TelecomSupportSystem.Infrastructure.Extensions
{
    public static class OptionConfigurations
    {
        public static void ConfigureInfrastructureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        }
    }
}
