using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using VolleyballChampionship.Api.Infra.AutoMapper;
using VolleyballChampionship.Api.UnitsOfWork;

namespace VolleyballChampionship.Api.Infra.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterWebAPIServices(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingModelRequest()));
            services.AddAutoMapper(x => x.AddProfile(new MappingModelResponse()));

            #region Units of Work

            //services.AddScoped<ChampionshipUoW>();
            services.AddTransient<GroupUoW>();

            services.AddTransient<ChampionshipUoW>();

            #endregion

            #region Providers
            //services.AddScoped<ITokenProvider, TokenProviderWeb>();
            #endregion

            return services;
        }
    }
}