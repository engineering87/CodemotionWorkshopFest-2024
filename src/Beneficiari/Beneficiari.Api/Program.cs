using Beneficiari.Api.Extensions;
using Beneficiari.Api.Swagger;
using Beneficiari.Application;
using Beneficiari.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(config);
builder.Services.AddApiVersioningExtension();
builder.Services.AddHealthChecks();

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
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
