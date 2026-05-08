using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TelecomSupportSystem.Domain.Entities;
using TelecomSupportSystem.Infrastructure.Persistence;

namespace TelecomSupportSystem.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<AppUser>()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}
