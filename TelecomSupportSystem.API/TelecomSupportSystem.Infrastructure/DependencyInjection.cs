using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelecomSupportSystem.Domain.Entities;
using TelecomSupportSystem.Infrastructure.Persistence;

namespace TelecomSupportSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}
