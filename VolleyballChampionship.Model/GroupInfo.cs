using Dapper.Contrib.Extensions;
using VolleyballChampionship.Model.Base;

namespace VolleyballChampionship.Model
{
    [Table("group_championship")]
    public class GroupInfo : BaseInfo
    {
        public string Description { get; set; }
        
        [Write(false)]
        public int ChampionshipId { get; set; }
    }
}
