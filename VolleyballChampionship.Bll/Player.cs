using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VolleyballChampionship.Bll.BaseBll;
using VolleyballChampionship.Bll.Infra;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Bll
{
    public class Player : BaseCrudBll<IPlayerDal, PlayerInfo>, IPlayer
    {
        public Player(IPlayerDal dal, IBaseDal baseDal, IHttpContextAccessor httpContextAccessor) : base(dal, baseDal, httpContextAccessor)
        {
        }
        
        public Task<List<PlayerInfo>> GetByParametersAsync(PlayerInfo info)
        {
            return _dal.GetByParametersAsync(info, _baseDal.GetConnection());
        }
    }
}

