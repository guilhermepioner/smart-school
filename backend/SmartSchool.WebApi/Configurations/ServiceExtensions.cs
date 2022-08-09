using System.Reflection;
using Microsoft.OpenApi.Models;

namespace SmartSchool.Api.Configurations;

public static class ServiceExtensions
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(configuration["Api:Version"], new OpenApiInfo
            {
                Version = configuration["Api:Version"],
                Title = configuration["Api:Name"],
                Description = $"{configuration["Api:Description"]} | Swagger Documentation"
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        return services;
    }
}