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
    public class PlayerDal : MySqlBaseCrudDal<PlayerInfo>, IPlayerDal
    {
        #region Methods
        public async Task<List<PlayerInfo>> GetByParametersAsync(PlayerInfo info, IDbConnection connection)
        {
            var sql = PlayerCommands._getByParameters;

            if (!string.IsNullOrEmpty(info.Name))
                sql += PlayerCommands._whereName;

            if (!string.IsNullOrEmpty(info.Nickname))
                sql += PlayerCommands._whereNickName;

            if (info.Id > 0)
                sql += PlayerCommands._wherePlayerId;

            var players = await connection.QueryAsync<PlayerInfo>(sql, new { info.Name, info.Nickname, info.Id });

            return players.ToList();
        }

        #endregion                 
    }
}
