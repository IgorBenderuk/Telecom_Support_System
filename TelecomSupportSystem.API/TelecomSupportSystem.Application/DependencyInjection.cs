using Microsoft.Extensions.DependencyInjection;
using TelecomSupportSystem.Application.Interfaces;
using TelecomSupportSystem.Application.Services;

namespace TelecomSupportSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
