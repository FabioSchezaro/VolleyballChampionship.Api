using VolleyballChampionship.Model.Enums;

namespace VolleyballChampionship.Api.Responses
{
    public class ChampionshipResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ChampionshipStatusEnum Status { get; set; }
    }
}
