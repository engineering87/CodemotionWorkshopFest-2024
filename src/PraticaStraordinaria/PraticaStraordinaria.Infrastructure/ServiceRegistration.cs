using Microsoft.Extensions.DependencyInjection;
using PraticaStraordinaria.Infrastructure.Persistence.Contexts;
using PraticaStraordinaria.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PraticaStraordinaria.Application.Interfaces.Repositories;

namespace PraticaStraordinaria.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var inmemory = configuration.GetSection("UseInMemoryDatabase")?.Value;

            if (inmemory != null && bool.Parse(inmemory))
            {
                services.AddDbContext<PraticheStraordinarieContext>(options =>
                    options.UseInMemoryDatabase("PraticheStraordinarieDB"));

                services.AddDbContext<PraticheLegacyContext>(options =>
                    options.UseInMemoryDatabase("PraticheLegacyDB"));
            }
            else
            {
                services.AddDbContext<PraticheStraordinarieContext>(options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("PraticaStraordinariaConnection"),
                       b => b.MigrationsAssembly(typeof(PraticheStraordinarieContext).Assembly.FullName)));

                services.AddDbContext<PraticheLegacyContext>(options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("PraticaLegacyConnection"),
                       b => b.MigrationsAssembly(typeof(PraticheLegacyContext).Assembly.FullName)));
            }

            #region Repositories
            services.AddTransient<IPraticaStraordinariaRepositoryAsync, PraticaStraordinariaRepositoryAsync>();
            services.AddTransient<IPraticaLegacyRepositoryAsync, PraticaLegacyRepositoryAsync>();
            #endregion
        }
    }
}
