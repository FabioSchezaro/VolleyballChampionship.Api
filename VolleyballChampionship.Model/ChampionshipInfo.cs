using Dapper.Contrib.Extensions;
using VolleyballChampionship.Model.Base;
using VolleyballChampionship.Model.Enums;

namespace VolleyballChampionship.Model
{
    [Table("championship")]
    public class ChampionshipInfo : BaseInfo
    {
        public string Description { get; set; }
        public ChampionshipStatusEnum Status { get; set; }
    }
}
