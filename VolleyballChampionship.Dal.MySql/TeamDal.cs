using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.MySql.MySqlBaseCrudDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.MySql
{
    public class TeamDal : MySqlBaseCrudDal<TeamInfo>, ITeamDal
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