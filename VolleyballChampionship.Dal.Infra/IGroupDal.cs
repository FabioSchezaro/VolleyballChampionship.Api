using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.Infra
{
    public interface IGroupDal : IBaseCrudDal<GroupInfo>
    {
        Task<List<GroupInfo>> GetGroupByChampionshipIdAsync(int championshipId);
    }
}
