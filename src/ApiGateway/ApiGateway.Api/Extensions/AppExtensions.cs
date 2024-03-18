using ApiGateway.Api.Middlewares;
using ApiGateway.Domain.Enums;
using Polly.Extensions.Http;
using Polly.Registry;
using Polly;

namespace ApiGateway.Api.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiGateway.WebApi");
            });
        }

        public static void UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public static void UsePollyPolicies(this WebApplication app)
        {
            var policyRegistry = app.Services.GetRequiredService<IPolicyRegistry<string>>();

            // POLLY POLICIES

            // Timeout Policy
            // - 60 secondi
            var timeOutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(30)
            );

            // Retry Policy
            // - 2 tentativi
            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(2, attempt =>
                TimeSpan.FromSeconds(1)
            );

            policyRegistry.Add(PollyPolicy.TIMEOUT_POLICY, timeOutPolicy);
            policyRegistry.Add(PollyPolicy.RETRY_POLICY, retryPolicy);
        }
    }
}
