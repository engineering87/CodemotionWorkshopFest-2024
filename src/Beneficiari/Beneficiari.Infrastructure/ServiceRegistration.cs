using Microsoft.Extensions.DependencyInjection;
using Beneficiari.Application.Interfaces;
using Beneficiari.Infrastructure.Persistence.Contexts;
using Beneficiari.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Beneficiari.Application.Interfaces.Repositories;
namespace Beneficiari.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var inmemory = configuration.GetSection("UseInMemoryDatabase")?.Value;

            if (inmemory != null && bool.Parse(inmemory))
            {
                services.AddDbContext<BeneficiariContext>(options =>
                    options.UseInMemoryDatabase("BeneficiariDB"));
            }
            else
            {
                services.AddDbContext<BeneficiariContext>(options =>
                   options.UseSqlServer(
                       configuration.GetConnectionString("BeneficiariConnection"),
                       b => b.MigrationsAssembly(typeof(BeneficiariContext).Assembly.FullName)));
            }

            #region Repositories
            services.AddTransient<IBeneficiariRepositoryAsync, BeneficiariRepositoryAsync>();
            #endregion
        }
    }
}
