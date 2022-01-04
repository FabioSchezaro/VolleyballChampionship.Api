using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using VolleyballChampionship.Api.Configuration;
using VolleyballChampionship.Api.Extensions;
using VolleyballChampionship.Api.Infra.Extensions;

namespace VolleyballChampionship.Api
{
    public class Startup
    {
        private readonly string _apiName;
        private readonly string _apiVersion;
        private readonly string _apiXmlDocumentName;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var assembly = Assembly.GetExecutingAssembly().GetName();
            _apiName = assembly.Name;
            _apiVersion = assembly.Version.ToString();
            _apiXmlDocumentName = assembly.Name + ".xml";
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddDependencyInjectorConfiguration(Configuration);
            services.RegisterWebAPIServices();
            services.AddAuthorizeConfiguration();
            services.AddControllers();
            AddCors(services);

            services.AddControllers();
        }

        private static void AddCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllOrigins", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);



                c.IncludeXmlComments(xmlPath);
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Teste CRUD",
                    Description = "Um CRUD de Teste"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            //app.UseVolleyballSwagger(_apiName, _apiVersion);
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Teste CRUD"));

            app.UseCors("AllOrigins");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
