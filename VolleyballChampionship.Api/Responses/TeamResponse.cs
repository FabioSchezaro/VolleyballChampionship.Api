namespace VolleyballChampionship.Api.Responses
{
    public class TeamResponse
    {
        public int Id { get; set; }
        public PlayerResponse Player1 { get; set; }
        public PlayerResponse Player2 { get; set; }
        public PlayerResponse Player3 { get; set; }
        public PlayerResponse Player4 { get; set; }
        public bool KeyHead { get; set; }
        public int PointsScored { get; set; }
        public int PointsTaken { get; set; }
        public float Average { get; set; }
        public int DifferencePoints { get; set; }
    }
}
