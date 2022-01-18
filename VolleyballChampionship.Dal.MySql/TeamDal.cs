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
    public class TeamDal : MySqlBaseCrudDal<TeamInfo>, ITeamDal
    {
        #region Methods

        public Task<List<TeamInfo>> GetTeamByGroupIdAsync(int groupId)
        {
            return Task.Run(() =>
            {
                List<TeamInfo> list = new List<TeamInfo>();

                return list;
            });
        }
     
        public async Task<List<TeamInfo>> GetByParametersAsync(TeamInfo info, IDbConnection connection)
        {
            var sql = TeamCommands._getByParameters;

            if (info.Id > 0)
                sql += TeamCommands._whereTeamId;

            var teams = await connection.QueryAsync<TeamInfo>(sql, new { info.Id });

            return teams.ToList();
        }

        #endregion        
    }
}