using VolleyballChampionship.Api.UnitsOfWork.Base;
using VolleyballChampionship.Bll.Infra;

namespace VolleyballChampionship.Api.UnitsOfWork
{
    public class GroupUoW : BaseUoW
    {
        public readonly IGroup _group;

        public GroupUoW(IGroup group)
        {
            _group = group;
        }
    }
}
