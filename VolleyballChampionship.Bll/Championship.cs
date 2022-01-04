using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyballChampionship.Bll.BaseBll;
using VolleyballChampionship.Bll.Infra;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Bll
{
    public class Championship : BaseCrudBll<IChampionshipDal, ChampionshipInfo>, IChampionship
    {
        public Championship(IChampionshipDal dal, IBaseDal baseDal, IHttpContextAccessor httpContextAccessor) : base(dal, baseDal, httpContextAccessor)
        {
        }

        public Task<List<ChampionshipInfo>> GetByParametersAsync(ChampionshipInfo info)
        {
            return _dal.GetByParametersAsync(info, _baseDal.GetConnection());
        }
    }
}
