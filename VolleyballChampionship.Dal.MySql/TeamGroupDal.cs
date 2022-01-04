using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.MySql.MySqlBaseCrudDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.MySql
{
    public class TeamGroupDal : MySqlBaseCrudDal<TeamGroupInfo>, ITeamGroupDal
    {
    }
}
