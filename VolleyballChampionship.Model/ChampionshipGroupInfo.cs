using Dapper.Contrib.Extensions;
using VolleyballChampionship.Model.Base;

namespace VolleyballChampionship.Model
{
    [Table("championship_x_group")]
    public class ChampionshipGroupInfo : BaseInfo
    {
        public int ChampionshipId { get; set; }
        public int GroupId { get; set; }
    }
}
