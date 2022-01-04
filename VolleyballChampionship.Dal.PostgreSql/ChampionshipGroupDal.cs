using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.PostgreSql.PostgreSqlBaseCrud;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.PostgreSql
{
    class ChampionshipGroupDal : PostgreSqlBaseCrudDal<ChampionshipGroupInfo>, IChampionshipGroupDal
    {
    }
}
