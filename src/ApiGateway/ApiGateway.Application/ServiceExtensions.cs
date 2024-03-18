using System.Reflection;
using ApiGateway.Application.Configuration;
using ApiGateway.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ApiGateway.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddSingleton<IConfigManager, ConfigManager>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
