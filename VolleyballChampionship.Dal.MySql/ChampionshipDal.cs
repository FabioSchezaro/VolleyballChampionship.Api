using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.MySql.Commands;
using VolleyballChampionship.Dal.MySql.MySqlBaseCrudDal;
using VolleyballChampionship.Model;
using VolleyballChampionship.Model.Enums;

namespace VolleyballChampionship.Dal.MySql
{
    public class ChampionshipDal : MySqlBaseCrudDal<ChampionshipInfo>, IChampionshipDal
    {
        #region SQL

        #endregion

        #region Properties

        private readonly IGroupDal _groupDal;

        #endregion

        #region Contructor

        public ChampionshipDal(IGroupDal groupDal)
        {
            _groupDal = groupDal;
        }

        #endregion

        #region Mapper


        #endregion

        #region Methods

        public async Task<List<ChampionshipInfo>> GetByParametersAsync(ChampionshipInfo info, IDbConnection connection)
        {
            var sql = ChampionshipCommands._sql;

            if (!string.IsNullOrEmpty(info.Description))
                sql += ChampionshipCommands._whereDescription;

            if (info.Status != 0)
                sql += ChampionshipCommands._whereStatus;

            var championships = await connection.QueryAsync<ChampionshipInfo>(sql, new { info.Description, info.Status });

            return championships.ToList();
        }

        #endregion
    }
}
