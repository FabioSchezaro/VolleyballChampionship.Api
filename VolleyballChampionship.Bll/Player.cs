using Microsoft.AspNetCore.Http;
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
    }
}

