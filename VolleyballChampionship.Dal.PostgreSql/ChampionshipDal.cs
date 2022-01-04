using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.PostgreSql.PostgreSqlBaseCrud;
using VolleyballChampionship.Model;
using VolleyballChampionship.Model.Enums;

namespace VolleyballChampionship.Dal.PostgreSql
{
    public class ChampionshipDal : PostgreSqlBaseCrudDal<ChampionshipInfo>
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

        public Task<List<ChampionshipInfo>> GetAllAsync()
        {
            return Task.Run(async () =>
            {
                List<ChampionshipInfo> list = new List<ChampionshipInfo>();

                for (int i = 0; i < 5; i++)
                {
                    ChampionshipInfo info = new ChampionshipInfo();

                    info.Description = $"{i + 1}º Rachão Amigos do Volei RP";
                    info.Status = ChampionshipStatusEnum.InProgress;

                    list.Add(info);
                }

                return list;
            });
        }

        #endregion
    }
}
