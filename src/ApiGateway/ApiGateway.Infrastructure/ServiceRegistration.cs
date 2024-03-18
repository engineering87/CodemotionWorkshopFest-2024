using Microsoft.Extensions.DependencyInjection;
using ApiGateway.Infrastructure.Api.Clients;
using System.Net;
using ApiGateway.Domain.Enums;

namespace ApiGateway.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddApiInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient<IPraticaOrdinariaClient, PraticaOrdinariaClient>(client =>
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            })
            .AddPolicyHandlerFromRegistry(PollyPolicy.TIMEOUT_POLICY)
            .AddPolicyHandlerFromRegistry(PollyPolicy.RETRY_POLICY);

            services.AddHttpClient<IPraticaStraordinariaClient, PraticaStraordinariaClient>(client =>
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            })
            .AddPolicyHandlerFromRegistry(PollyPolicy.TIMEOUT_POLICY)
            .AddPolicyHandlerFromRegistry(PollyPolicy.RETRY_POLICY);

            services.AddHttpClient<IBeneficiarioClient, BeneficiarioClient>(client =>
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            })
            .AddPolicyHandlerFromRegistry(PollyPolicy.TIMEOUT_POLICY)
            .AddPolicyHandlerFromRegistry(PollyPolicy.RETRY_POLICY);
        }
    }
}
