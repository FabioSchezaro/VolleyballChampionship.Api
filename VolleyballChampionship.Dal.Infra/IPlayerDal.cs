using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.Infra
{
    public interface IPlayerDal : IBaseCrudDal<PlayerInfo>
    {
        Task<List<PlayerInfo>> GetByParametersAsync(PlayerInfo info, IDbConnection dbConnection);
    }
}
