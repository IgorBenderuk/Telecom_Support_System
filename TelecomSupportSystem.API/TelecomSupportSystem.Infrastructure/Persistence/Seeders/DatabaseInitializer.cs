using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TelecomSupportSystem.Domain.Entities;

namespace TelecomSupportSystem.Infrastructure.Persistence.Seeders
{
    public class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var roleManager = scope.ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            foreach ( var role in new[] { Roles.Agent, Roles.Customer, Roles.Admin } )
            {
                if ( !await roleManager.RoleExistsAsync(role) )
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
