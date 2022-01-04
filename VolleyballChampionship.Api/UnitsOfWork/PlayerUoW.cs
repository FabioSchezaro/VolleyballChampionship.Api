using VolleyballChampionship.Api.UnitsOfWork.Base;
using VolleyballChampionship.Bll.Infra;

namespace VolleyballChampionship.Api.UnitsOfWork
{
    public class PlayerUoW : BaseUoW
    {
        public IPlayer _player;

        public PlayerUoW(IPlayer player)
        {
            _player = player;
        }
    }
}
