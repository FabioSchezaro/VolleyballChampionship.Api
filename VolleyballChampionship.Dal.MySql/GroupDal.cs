using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.MySql.Commands;
using VolleyballChampionship.Dal.MySql.MySqlBaseCrudDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.MySql
{
    public class GroupDal : MySqlBaseCrudDal<GroupInfo>, IGroupDal
    {
        #region Properties

        private readonly ITeamDal _teamDal;

        #endregion

        #region Contructor

        public GroupDal(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        #endregion

        #region Methods

        public Task<List<GroupInfo>> GetGroupByChampionshipIdAsync(int championshipId)
        {
            return Task.Run(() =>
            {
                List<GroupInfo> list = new List<GroupInfo>();

                return list;
            });
        }
        public async Task<List<GroupInfo>> GetByParametersAsync(GroupInfo info, IDbConnection connection)
        {
            var sql = GroupCommands._getByParameters;

            if (!string.IsNullOrEmpty(info.Description))
                sql += GroupCommands._whereDescription;

            if (info.ChampionshipId > 0)
                sql += GroupCommands._whereChampionshipId;

            if (info.Id > 0)
                sql += GroupCommands._whereGroupId;

            var groups = await connection.QueryAsync<GroupInfo>(sql, new { info.Description, info.ChampionshipId, info.Id });

            return groups.ToList();
        }

        #endregion
    }
}
