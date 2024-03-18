using Microsoft.Extensions.Options;
using ApiGateway.Api.Extensions;
using ApiGateway.Api.Swagger;
using ApiGateway.Application;
using ApiGateway.Infrastructure.Persistence;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
builder.Services.AddApplicationLayer();
builder.Services.AddApiInfrastructure();
builder.Services.AddApiVersioningExtension();
builder.Services.AddHealthChecks();
builder.Services.AddPolicyRegistry();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var descriptions = app.DescribeApiVersions();

    foreach (var description in descriptions)
    {
        var url = $"/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName;
        options.SwaggerEndpoint(url, name);
    }
});
app.UseSwaggerExtension();
app.UseMiddlewares();
app.UseCors("AllowAll");
app.UsePollyPolicies();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
