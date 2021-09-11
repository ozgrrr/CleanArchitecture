using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var currentDb = configuration.GetConnectionString("CurrentDatabase");

            var connectionString = configuration.GetConnectionString("PostgreConnectionString");

            if (currentDb == "PostgreDb")
            {
                services.AddDbContext<AtDbContext>(options =>
                {
                    options.UseNpgsql(connectionString, x =>
                    {
                        x.MigrationsHistoryTable("_MigrationHistory");
                    });
                });

                services.AddTransient<IAtDbContext>(provider => provider.GetService<AtDbContext>());
            }

            return services;
        }
    }
}
