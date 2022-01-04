using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Dal.Infra
{
    public interface ITeamDal : IBaseCrudDal<TeamInfo>
    {
        Task<List<TeamInfo>> GetTeamByGroupIdAsync(int chapionshipId);
    }
}
