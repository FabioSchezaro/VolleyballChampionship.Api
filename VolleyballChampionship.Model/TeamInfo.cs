using Dapper.Contrib.Extensions;
using VolleyballChampionship.Model.Base;

namespace VolleyballChampionship.Model
{
    [Table("team")]
    public class TeamInfo : BaseInfo
    {
        public PlayerInfo Player1 { get; set; }
        public PlayerInfo Player2 { get; set; }
        public PlayerInfo Player3 { get; set; }
        public PlayerInfo Player4 { get; set; }
        public bool KeyHead { get; set; }
        public int PointsScored { get; set; }
        public int PointsTaken { get; set; }
        public float Average { get; set; }
        public int DifferencePoints { get; set; }
    }
}
