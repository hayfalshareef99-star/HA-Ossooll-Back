using HA_Ossooll.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HA_Ossooll.Data.Data;

namespace HA_Ossooll.Data.Configurations;

public static class DataConfiguration
{
    public static IServiceCollection AddProjectDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        //services.AddDbContext<AppDbContext>(options =>
        //    options.UseSqlServer(AppDbContext.DBConnectionString));

        return services;
    }
}