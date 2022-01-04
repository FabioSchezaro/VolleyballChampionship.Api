namespace VolleyballChampionship.Api.Responses
{
    public class GroupResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ChampionshipResponse Championship { get; set; }
    }
}
