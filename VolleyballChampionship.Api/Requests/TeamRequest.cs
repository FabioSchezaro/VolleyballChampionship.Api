using VolleyballChampionship.Api.Requests.Base;

namespace VolleyballChampionship.Api.Requests
{
    public class TeamRequest : BaseRequest
    {
        public int Id { get; set; }
        public PlayerRequest Player1 { get; set; }
        public PlayerRequest Player2 { get; set; }
        public PlayerRequest Player3 { get; set; }
        public PlayerRequest Player4 { get; set; }
        public bool KeyHead { get; set; }
        public int PointsScored { get; set; }
        public int PointsTaken { get; set; }
        public float Average { get; set; }
        public int DifferencePoints { get; set; }
    }
}
