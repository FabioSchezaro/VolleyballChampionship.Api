using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.MySql.MySqlBaseCrudDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.MySql
{
    public class GroupDal : MySqlBaseCrudDal<GroupInfo>, IGroupDal
    {
        private readonly ITeamDal _teamDal;

        public GroupDal(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public Task<List<GroupInfo>> GetGroupByChampionshipIdAsync(int championshipId)
        {
            return Task.Run(() =>
            {
                List<GroupInfo> list = new List<GroupInfo>();

                return list;
            });
        }
    }
}
