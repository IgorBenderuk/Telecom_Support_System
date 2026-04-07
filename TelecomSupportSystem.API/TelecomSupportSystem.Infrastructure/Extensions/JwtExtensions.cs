using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TelecomSupportSystem.Infrastructure.Options;

namespace TelecomSupportSystem.Infrastructure.Extensions
{
    public static class JwtExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    var options = configuration.GetSection("Jwt").Get<JwtOptions>()
                        ?? throw new InvalidOperationException("Jwt configuration section is missing");

                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,

                        ValidIssuer = options.Issuer,
                        ValidAudience = options.Audience,

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(options.Key))
                    };
                });

            return services;
        }
    }
}
