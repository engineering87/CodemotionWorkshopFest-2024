using Asp.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Beneficiari.Api.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Beneficiari.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                .AddApiVersioning(config =>
                {
                    // Specify the default API Version as 1.0
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    // If the client hasn't specified the API version in the request, use the default API version number 
                    config.AssumeDefaultVersionWhenUnspecified = true;
                    // Advertise the API versions supported for the particular endpoint
                    config.ReportApiVersions = true;
                })
                .AddApiExplorer(options =>
                {
                    // Add the versioned API explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
        }
    }
}