using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Ocelot.Configuration.File;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace VolleyballChampionship.Gateway.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwaggerUI(setup =>
            {
                foreach (var service in configuration.Get<FileConfiguration>().ReRoutes)
                {
                    if (!service.UpstreamHeaderTransform.Contains(new KeyValuePair<string, string>("X-Swagger", "True")))
                        continue;

                    var address = service.DownstreamHostAndPorts.FirstOrDefault();

                    if (address == null)
                        continue;

                    var serviceName = address.Host;
                    var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    var url = $"{service.DownstreamScheme}://{address.Host}:{address.Port}/swagger/docs/{version}";
                    var jsonEndpoint = $"/swagger/v1/swagger.json";
                    app.Map(jsonEndpoint, appBuilder =>
                    {
                        appBuilder.Run(async httpContext =>
                        {
                            var content = _httpClient.GetStringAsync(url).GetAwaiter().GetResult();
                            await httpContext.Response.WriteAsync(content);
                        });
                    });

                    setup.SwaggerEndpoint(jsonEndpoint, serviceName);
                }
            });

            return app;
        }
    }
}