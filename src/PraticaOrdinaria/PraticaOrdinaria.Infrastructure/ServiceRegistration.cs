using Microsoft.Extensions.DependencyInjection;
using PraticaOrdinaria.Infrastructure.Persistence.Contexts;
using PraticaOrdinaria.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PraticaOrdinaria.Application.Interfaces.Repositories;

namespace PraticaOrdinaria.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var inmemory = configuration.GetSection("UseInMemoryDatabase")?.Value;

            if (inmemory != null && bool.Parse(inmemory))
            {
                services.AddDbContext<PraticheOrdinarieContext>(options =>
                    options.UseInMemoryDatabase("PraticheOrdinarieDB"));

                services.AddDbContext<PraticheLegacyContext>(options =>
                    options.UseInMemoryDatabase("PraticheLegacyDB"));
            }
            else
            {
                services.AddDbContext<PraticheOrdinarieContext>(options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("PraticaOrdinariaConnection"),
                       b => b.MigrationsAssembly(typeof(PraticheOrdinarieContext).Assembly.FullName)));

                services.AddDbContext<PraticheLegacyContext>(options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("PraticaLegacyConnection"),
                       b => b.MigrationsAssembly(typeof(PraticheLegacyContext).Assembly.FullName)));
            }

            #region Repositories
            services.AddTransient<IPraticaOrdinariaRepositoryAsync, PraticaOrdinariaRepositoryAsync>();
            services.AddTransient<IPraticaLegacyRepositoryAsync, PraticaLegacyRepositoryAsync>();
            #endregion
        }
    }
}
