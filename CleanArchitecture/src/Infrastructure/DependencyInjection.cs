using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArchitectureDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CleanArchitectureContext"),
                    b => b.MigrationsAssembly(typeof(CleanArchitectureDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<ICleanArchitectureDbContext>(provider => provider.GetService<CleanArchitectureDbContext>());

            return services;
        }
    }
}
