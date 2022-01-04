using VolleyballChampionship.Api.UnitsOfWork.Base;
using VolleyballChampionship.Bll.Infra;

namespace VolleyballChampionship.Api.UnitsOfWork
{
    public class TeamUoW : BaseUoW
    {
        public ITeam _team;

        public TeamUoW(ITeam team)
        {
            _team = team;
        }
    }
}
