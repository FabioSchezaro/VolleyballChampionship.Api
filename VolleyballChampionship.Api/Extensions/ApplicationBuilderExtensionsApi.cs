using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;

namespace VolleyballChampionship.Api.Extensions
{
    public static class ApplicationBuilderExtensionsApi
    {
        public static IServiceCollection AddVolleyballSwagger(this IServiceCollection services, string apiName, string apiVersion, string xmlCommentsFileName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(apiVersion, new OpenApiInfo
                {

                    Title = apiName,
                    Version = apiVersion
                });

                string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                string applicationName = PlatformServices.Default.Application.ApplicationName;
                string xmlDocPath = Path.Combine(applicationPath, $"{applicationName}.xml");
                c.IncludeXmlComments(xmlDocPath);

                //c.AddSecurityDefinition("Bearer",
                //    new ApiKeyScheme
                //    {
                //        In = "header",
                //        Description = "Autenticação por JWT usando o schema Bearer . Exemplo: \"Bearer {token}\"",
                //        Name = "Authorization",
                //        Type = "apiKey"
                //    });

                c.EnableAnnotations();

                //c.DocumentFilter<DocumentFilter>();
                //c.OperationFilter<OperationFilter>();
            });

            return services;
        }
    }
}
