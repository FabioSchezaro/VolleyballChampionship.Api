using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VolleyballChampionship.Api.Configuration
{
    public static class DependencyInjectorConfiguration
    {
        public static void AddDependencyInjectorConfiguration(this IServiceCollection service, IConfiguration configuration) =>
            IoC.DependencyInjection.Register(service, configuration);
    }
}
