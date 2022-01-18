using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyballChampionship.Bll.Infra.IBaseBll;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Bll.Infra
{
    public interface ITeam : IBaseCrudBll<TeamInfo>
    {
        Task<List<TeamInfo>> GetByParametersAsync(TeamInfo teamInfo);
    }
}
