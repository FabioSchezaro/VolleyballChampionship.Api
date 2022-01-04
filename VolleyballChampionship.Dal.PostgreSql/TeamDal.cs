using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.PostgreSql.PostgreSqlBaseCrud;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.PostgreSql
{
    public class TeamDal : PostgreSqlBaseCrudDal<TeamInfo>, ITeamDal
    {
        public Task<List<TeamInfo>> GetTeamByGroupIdAsync(int groupId)
        {
            return Task.Run(() =>
            {
                List<TeamInfo> list = new List<TeamInfo>();

                return list;
            });
        }
    }
}