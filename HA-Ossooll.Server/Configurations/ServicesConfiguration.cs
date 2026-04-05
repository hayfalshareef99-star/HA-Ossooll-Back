using HA_Ossooll.Services.IService;
using Microsoft.Extensions.DependencyInjection;

namespace HA_Ossooll.Services.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}