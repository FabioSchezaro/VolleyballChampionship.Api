using VolleyballChampionship.Api.Requests.Base;
using VolleyballChampionship.Model.Enums;

namespace VolleyballChampionship.Api.Requests
{
    public class PlayerRequest : BaseRequest
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
