using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolleyballChampionship.Bll;
using VolleyballChampionship.Bll.Infra;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Dal.MySql.MySqlBaseCrudDal;
using VolleyballChampionship.Dal.MySql;

namespace VolleyballChampionship.IoC
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IBaseDal>(s =>
                new BaseDal(configuration.GetConnectionString("VolleiballPostgreSqlConnectionString")));

            service.AddScoped<IChampionship, Championship>();
            service.AddScoped<IChampionshipDal, ChampionshipDal>();

            service.AddScoped<IGroup, Group>();
            service.AddScoped<IGroupDal, GroupDal>();

            service.AddScoped<IPlayer, Player>();
            service.AddScoped<IPlayerDal, PlayerDal>();

            service.AddScoped<ITeam, Team>();
            service.AddScoped<ITeamDal, TeamDal>();

            service.AddScoped<IChampionshipGroup, ChampionshipGroup>();
            service.AddScoped<IChampionshipGroupDal, ChampionshipGroupDal>();

            service.AddScoped<ITeamGroup, TeamGroup>();
            service.AddScoped<ITeamGroupDal, TeamGroupDal>();

            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
