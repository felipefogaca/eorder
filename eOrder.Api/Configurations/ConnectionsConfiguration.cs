using eOrder.Infra;
using Microsoft.EntityFrameworkCore;

namespace eOrder.Api.Configurations
{
    public static class ConnectionsConfiguration
    {
        public static IServiceCollection AddDbConnections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            return services;
        }
    }
}
