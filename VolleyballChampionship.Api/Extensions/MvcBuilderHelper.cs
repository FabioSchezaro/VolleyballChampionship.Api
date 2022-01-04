using Microsoft.AspNetCore.Builder;

namespace VolleyballChampionship.Api.Extensions
{
    public static class MvcBuilderHelper
    {
        public static IApplicationBuilder UseVolleyballSwagger(this IApplicationBuilder app, string apiName, string apiVersion, bool hasGateway = true)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/docs/{documentName}";
                //c.PreSerializeFilters.Add((swagger, httpReq) =>
                //{
                //    swagger.Host = hasGateway ? string.Empty : httpReq.Host.Value;
                //});
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/docs/" + apiVersion, apiName);
            });

            return app;
        }
    }
}
