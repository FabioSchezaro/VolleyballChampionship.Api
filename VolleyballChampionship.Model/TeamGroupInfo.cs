using Dapper.Contrib.Extensions;
using VolleyballChampionship.Model.Base;

namespace VolleyballChampionship.Model
{
    [Table("group_x_team")]
    public class TeamGroupInfo : BaseInfo
    {
        public int GroupId { get; set; }
        public int TeamId { get; set; }
    }
}
