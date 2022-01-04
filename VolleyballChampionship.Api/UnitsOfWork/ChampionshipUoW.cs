using VolleyballChampionship.Api.UnitsOfWork.Base;
using VolleyballChampionship.Bll.Infra;

namespace VolleyballChampionship.Api.UnitsOfWork
{
    public class ChampionshipUoW : BaseUoW
    {
        public readonly IChampionship _championship;

        public ChampionshipUoW(IChampionship championship)
        {
            _championship = championship;
        }
    }
}
