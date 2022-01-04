using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.PostgreSql.PostgreSqlBaseCrud;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.PostgreSql
{
    public class GroupDal : PostgreSqlBaseCrudDal<GroupInfo>, IGroupDal
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
