using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.Infra
{
    public interface IChampionshipDal : IBaseCrudDal<ChampionshipInfo>
    {
        Task<List<ChampionshipInfo>> GetByParametersAsync(ChampionshipInfo info, IDbConnection connection);
    }
}
