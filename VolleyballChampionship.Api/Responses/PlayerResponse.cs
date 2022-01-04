using VolleyballChampionship.Model.Enums;

namespace VolleyballChampionship.Api.Responses
{
    public class PlayerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public GerdenEnum Gender { get; set; }
        public int PointsScored { get; set; }
        public int PointsTaken { get; set; }
        public float Average { get; set; }
        public int DifferencePoints { get; set; }
    }
}
