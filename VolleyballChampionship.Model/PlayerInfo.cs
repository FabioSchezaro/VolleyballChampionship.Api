using Dapper.Contrib.Extensions;
using VolleyballChampionship.Model.Base;
using VolleyballChampionship.Model.Enums;

namespace VolleyballChampionship.Model
{
    [Table("player")]
    public class PlayerInfo : BaseInfo
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public GerdenEnum Gender { get; set; }
        public int ScoredPoints { get; set; }
        public int TakenPoints { get; set; }
        public float AveragePoints { get; set; }
        public int DifferencePoints { get; set; }
    }
}
