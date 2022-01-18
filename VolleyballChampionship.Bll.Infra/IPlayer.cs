using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyballChampionship.Bll.Infra.IBaseBll;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Bll.Infra
{
    public interface IPlayer : IBaseCrudBll<PlayerInfo>
    {
        Task<List<PlayerInfo>> GetByParametersAsync(PlayerInfo playerInfo);
    }
}
