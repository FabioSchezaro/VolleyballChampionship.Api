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
    public class Team : BaseCrudBll<ITeamDal, TeamInfo>, ITeam
    {
        public Team(ITeamDal dal, IBaseDal baseDal, IHttpContextAccessor httpContextAccessor) : base(dal, baseDal, httpContextAccessor)
        {
        }

        public Task<List<TeamInfo>> GetByParametersAsync(TeamInfo info)
        {
            return _dal.GetByParametersAsync(info, _baseDal.GetConnection());
        }
    }
}
